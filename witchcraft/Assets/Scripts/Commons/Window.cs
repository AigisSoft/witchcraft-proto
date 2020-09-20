using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Commons
{
    /// <summary>
    /// 基底パラメータ
    /// </summary>
    public struct WindowParameter
    {
        string WindowName;
        private Vector2Int windowPosition;
        public Vector2Int WindowPosition
        {
            get
            {
                return windowPosition;
            }
            set
            {
                //位置変更時に更新処理を行う
                windowPosition = value;
            }
        }

        private Vector2Int windowSize;
        public Vector2Int WindowSize
        {
            get
            {
                return windowSize;
            }
            set
            {
                //サイズ変更時に更新処理をおこなう
                windowSize = value;
            }
        }

    }

    public class Window : MonoBehaviour
    {
        private WindowParameter parameter;
        public WindowParameter Parameter
        {
            get { return parameter; }
            set { parameter = value; }
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
