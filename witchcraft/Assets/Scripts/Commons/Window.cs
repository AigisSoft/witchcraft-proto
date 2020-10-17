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
        private string windowName;
        public string WindowName
        {
            get { return windowName; }
        }

        private Vector2Int windowPosition;
        public Vector2Int WindowPosition
        {
            get
            {
                return windowPosition;
            }
            set
            {

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

        private WindowType type = WindowType.None;
        public WindowType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <returns></returns>
        public virtual bool Initialize()
        {
            return true;
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        public virtual void Close()
        {
            //ManagerのClose時処理を呼ぶようにする
        }
    }
}
