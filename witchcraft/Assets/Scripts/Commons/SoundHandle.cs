using System;

namespace Assets.Scripts.Commons
{
    public class SoundHandle
    {
        UInt16 Category = 0;
        UInt16 Number = 0;

        public SoundHandle(UInt16 category = 0, UInt16 number = 0)
        {
            Category = category;
            Number = number;
        }
    }
}