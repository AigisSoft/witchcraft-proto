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
        /// 待機
        /// </summary>
        Idle,
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

            status = SoundStatus.Idle;

            parameter = param;

            Source = this.gameObject.AddComponent<AudioSource>();
            if (Source == null)
                return;

            Source.volume = parameter.Volume;


            Task<bool> isExist = AddressablesUtil.ExistsAsync(parameter.Address);
            if (await isExist)
            {
                status = SoundStatus.Inactive;
                Debug.LogErrorFormat("SoundLoadError : Invalid Address [{0}]", parameter.Address);
                return;
            }

            status = SoundStatus.Loading;
            Handle = Addressables.LoadAssetAsync<AudioClip>(parameter.Address);
            Handle.Completed += LoadCompleted;
        }

        /// <summary>
        /// 再生処理
        /// </summary>
        /// <returns>true:成功 / false:失敗</returns>
        public bool Play()
        {
            if (!Source.isPlaying && status == SoundStatus.Loaded)
            {
                Source.Play();
                status = SoundStatus.Playing;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 停止処理　（即解放）
        /// </summary>
        /// <returns>true:成功 / false:失敗</returns>
        public bool Stop()
        {
            if(Source.isPlaying && status == SoundStatus.Playing)
            {
                Source.Stop();
                status = SoundStatus.Inactive;

                Addressables.Release(Handle);
                return true;
            }
            return false;
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
                if(!Play())
                {
                    Debug.LogErrorFormat("SoundPlayError : Unable to play");
                }
            }
        }
    }
}