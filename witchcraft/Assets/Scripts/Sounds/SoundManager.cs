using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

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

        public SoundHandle Play(SoundParameter parameter)
        {
            if (parameter.Category == SoundCategory.NONE)
                return null;

            SoundHandle handle = new SoundHandle();
            Sound sound = null;

            switch(parameter.Category)
            {
                case SoundCategory.BGM:
                    break;
            }

            Task t = sound.Load(parameter);

            return handle;
        }
    }
}

