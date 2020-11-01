using System;
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
        private Action onOpened = null;
        private Action onClosed = null;

        private bool isOpen = false;
        public bool IsOpne = true;

        private WindowParameter parameter;
        public WindowParameter Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }

        private WindowType type = WindowType.NONE;
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
        /// Windowを開く(表示する)
        /// Managerから呼び出される
        /// </summary>
        /// <returns></returns>
        public virtual void OnOpen()
        {
            if (isOpen)
                throw new Exception(parameter.WindowName + " is already open.");
            isOpen = true;

            if (onOpened != null)
                onOpened?.Invoke();
        }

        /// <summary>
        /// Windowを閉じる(非表示にする)
        /// Managerから呼び出される
        /// </summary>
        public virtual void OnClose()
        {
            if (!isOpen)
                throw new Exception(parameter.WindowName + " is already close.");
            isOpen = false;

            if (onClosed != null)
                onClosed?.Invoke();
        }

        /// <summary>
        /// 自己破棄処理
        /// </summary>
        public void SelfDestroy()
        {
            Destroy(gameObject);
        }
    }
}
