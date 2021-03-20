using UnityEngine;
using System.Collections;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using System.Threading.Tasks;



namespace Assets.Scripts.Sounds
{
    /// <summary>
    /// サウンドパラメータ
    /// </summary>
    public struct SoundParameter
    {
        /// <summary>
        /// アドレス
        /// </summary>
        public string Address;

        /// <summary>
        /// カテゴリ
        /// </summary>
        public SoundCategory Category;

        /// <summary>
        /// 音量　0.0f～1.0f
        /// </summary>
        public float Volume;

        /// <summary>
        /// Load後再生を行う
        /// </summary>
        public bool Immediately;

        public SoundParameter(string address, SoundCategory category = SoundCategory.NONE,float volume = 1.0f,bool immediately = true)
        {
            Address = address;
            Category = category;
            Volume = volume;
            Immediately = immediately;
        }
    }

    public enum SoundStatus
    {
        /// <summary>
        /// 有効ではない
        /// </summary>
        Inactive,
        /// <summary>
        /// ロード中
        /// </summary>
        Loading,
        /// <summary>
        /// ロード完了
        /// </summary>
        Loaded,
        /// <summary>
        /// 再生中
        /// </summary>
        Playing,
        /// <summary>
        /// 一時停止中
        /// </summary>
        Suspended,
        /// <summary>
        /// 解放
        /// </summary>
        Release,
    }

    public class Sound : MonoBehaviour
    {
        private SoundParameter parameter;
        public SoundParameter Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }

        private SoundStatus status = SoundStatus.Inactive;
        public SoundStatus Status
        {
            get { return status; }
        }


        AudioSource Source;
        private AudioClip Audio;
        AsyncOperationHandle<AudioClip> Handle;
        

        public Action Loaded = null;

        public void Start()
        {
            SoundParameter p = new SoundParameter();
            Load(p);
        }

        /// <summary>
        /// AudioClipLoad
        /// ※非同期
        /// </summary>
        /// <param name="param"></param>
        public async Task Load(SoundParameter param)
        {
            if (status != SoundStatus.Inactive)
                return;

            parameter = param;

            Source = this.gameObject.AddComponent<AudioSource>();
            if (Source == null)
                return;

            Source.volume = parameter.Volume;


            Task<bool> isExist = AddressablesUtil.ExistsAsync("Assets/Audio/same_bgm.mp3");
            if (!await isExist)
            {
                status = SoundStatus.Inactive;
                return;
            }

            status = SoundStatus.Loading;
            Handle = Addressables.LoadAssetAsync<AudioClip>("Assets/Audio/same_bgm.mp3");
            Handle.Completed += LoadCompleted;
        }

        public void Play()
        {
            Source.Play();
            status = SoundStatus.Playing;
        }

        public void Stop()
        {

        }

        /// <summary>
        /// Load完了処理
        /// </summary>
        /// <param name="handle"></param>
        private void LoadCompleted(AsyncOperationHandle<AudioClip> handle)
        {
            status = SoundStatus.Loaded;

            Audio = Handle.Result;
            Source.clip = Audio;
            if (parameter.Immediately)
            {
                Play();
            }
        }
    }
}