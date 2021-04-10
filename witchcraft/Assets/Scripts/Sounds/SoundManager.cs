using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System;

namespace Assets.Scripts.Sounds
{
    public enum SoundCategory
    {
        NONE,
        /// <summary>
        /// 2D Loop
        /// </summary>
        BGM,
        /// <summary>
        /// 3D
        /// </summary>
        UI,
        /// <summary>
        /// 2D
        /// </summary>
        BATTLE,
    }


    public class SoundManager : Singleton<SoundManager>
    {
        public const int MAX_BGM_COUNT = 8;
        public const int MAX_UI_SE_COUNT = 64;
        public const int MAX_BATTLE_SE_COUNT = 64;


        private Sound[] BGMList = new Sound[MAX_BGM_COUNT];
        private Sound[] UIList = new Sound[MAX_UI_SE_COUNT];
        private Sound[] BattleList = new Sound[MAX_BATTLE_SE_COUNT];

        public int BGMCount = 0;
        public int UICount = 0;
        public int BattleCount = 0;

        /// <summary>
        /// 再生処理
        /// </summary>
        /// <param name="parameter">サウンドパラメータ</param>
        /// <returns>サウンドハンドル 失敗時:null</returns>
        public SoundHandle Play(SoundParameter parameter)
        {
            if (parameter.Category == SoundCategory.NONE)
                return null;

            SoundHandle handle = new SoundHandle();

            GameObject gameObject = new GameObject("");
            Sound sound = gameObject.AddComponent<Sound>();

            //Sound sound = new Sound();

            bool resultFlg = false;

            switch(parameter.Category)
            {
                case SoundCategory.BGM:
                    for (int i = 0; i < MAX_BGM_COUNT; i++)
                    {
                        if(BGMList[i] == null || BGMList[i].Status == SoundStatus.Inactive)
                        {
                            BGMList[i] = sound;
                            handle.Number = (UInt16)i;
                            resultFlg = true;

                            break;
                        }
                    }

                    break;
                case SoundCategory.UI:
                    for (int i = 0; i < MAX_UI_SE_COUNT; i++)
                    {
                        if (UIList[i] == null || UIList[i].Status == SoundStatus.Inactive)
                        {
                            UIList[i] = sound;
                            handle.Number = (UInt16)i;
                            resultFlg = true;

                            break;
                        }
                    }

                    break;
                case SoundCategory.BATTLE:
                    for (int i = 0; i < MAX_BATTLE_SE_COUNT; i++)
                    {
                        if (BattleList[i] == null || BattleList[i].Status == SoundStatus.Inactive)
                        {
                            BattleList[i] = sound;
                            handle.Number = (UInt16)i;
                            resultFlg = true;

                            break;
                        }
                    }

                    break;

                default:
                    break;
            }

            if(!resultFlg)
            {
                Debug.LogWarningFormat("SoundPlayError : Max instance over");
                return null;
            }

            handle.Category = (UInt16)parameter.Category;

            Task t = sound.Load(parameter);

            return handle;
        }

        /// <summary>
        /// 停止処理
        /// </summary>
        /// <param name="handle">サウンドハンドル</param>
        /// <returns>true:成功 / false:失敗</returns>
        public bool Stop(SoundHandle handle)
        {
            Sound sound = ConvertHandleToSound(handle);
            if(sound == null)
            {
                return false;
            }

            sound.Stop();


            return true;
        }

        public bool IsActive(SoundHandle handle)
        {
            if (handle == null)
                return false;

            Sound sound = ConvertHandleToSound(handle);
            if (sound == null)
                return false;

            return true;
        }

        /// <summary>
        /// サウンドハンドルからサウンドに変換
        /// </summary>
        /// <param name="handle">サウンドハンドル</param>
        /// <returns>サウンド　失敗時null</returns>
        private Sound ConvertHandleToSound(SoundHandle handle)
        {
            switch((SoundCategory)handle.Category)
            {
                case SoundCategory.BGM:
                    return BGMList[handle.Number];
                case SoundCategory.UI:
                    return UIList[handle.Number];
                case SoundCategory.BATTLE:
                    return BattleList[handle.Number];
                default:
                    return null;
            }

        }
    }
}

