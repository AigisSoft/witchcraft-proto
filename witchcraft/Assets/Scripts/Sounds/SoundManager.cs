using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Commons
{
    public enum SoundCategory
    {
        NONE,
        BGM,    //2D Loop
        UI,     //3D
        BATTLE, //2D
    }


    public class SoundManager : MonoBehaviour
    {
        public SoundHandle Play()
        {
            SoundHandle handle = new SoundHandle();



            return handle;
        }
    }
}

