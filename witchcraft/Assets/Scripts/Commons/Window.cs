using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Commons
{
    public class Window : MonoBehaviour
    {
        private string windowName = string.Empty;
        public string WinndowName
        {
            get
            {
                return windowName;
            }
            set
            {
                windowName = value;
            }
        }

        private WindowType type = WindowType.none;
        public WindowType Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual bool Initialize()
        {
            return true;
        }

        public virtual void Close()
        {
        }
    }
}
