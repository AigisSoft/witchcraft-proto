using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

namespace Commons
{
    public enum WindowType
    {
        NONE,
        MESSAGE_DIALOG
    }

    public class WindowManager : Singleton<WindowManager>
    {
        static private List<Window> windowList = null;
        static Canvas canvas = null;

        public enum RESULT_CODE
        {
            SUCCESS = 0x0000,

            CREATE_ERROR = 0x0100,
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        ~WindowManager()
        {
            if (windowList != null)
            {
                if (windowList.Count > 0)
                {
                    foreach (Window _wid in windowList)
                    {
                        _wid.OnClose();
                    }
                }
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public override void Initialize()
        {
            windowList = new List<Window>();
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        }

        /// <summary>
        /// Windowを表示させる
        /// </summary>
        /// <param name="openWindow"></param>
        public void OpenWindow(Window openWindow)
        {
            try
            {
                openWindow.OnOpen();

                bool reopneFlg = false;
                for(int index = 0;index < windowList.Count; index++)
                {
                    if(windowList[index] == openWindow)
                    {
                        reopneFlg = true;
                        break;
                    }
                }

                if (!reopneFlg)
                    openWindow.transform.parent = canvas.transform;

                windowList.Add(openWindow);
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("WindowManager::OpenWindow : openWindow is null");
            }
            catch (Exception err)
            {
                Console.WriteLine("WindowManager::OpenWindow : " + err.Message);
            }
        }

        /// <summary>
        /// Windowを非表示にする
        /// </summary>
        /// <param name="closeWindow"></param>
        public void CloseWindow(Window closeWindow)
        {
            try
            {
                closeWindow.OnClose();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("WindowManager::CloseWindow : closeWindow is null");
            }
            catch (Exception err)
            {
                Console.WriteLine("WindowManager::CloseWindow : " + err.Message);
            }
        }

        /// <summary>
        /// Windowの削除
        /// </summary>
        /// <param name="destroyWindow"></param>
        public void DestroyWindow(Window destroyWindow)
        {
            try
            {
                if(!destroyWindow.IsOpne)
                {
                    CloseWindow(destroyWindow);
                }

                windowList.Remove(destroyWindow);

                destroyWindow.transform.parent = null;
                destroyWindow.SelfDestroy();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("WindowManager::DestroyWindow : destroyWindow is null");
            }
            catch (Exception err)
            {
                Console.WriteLine("WindowManager::DestroyWindow : " + err.Message);
            }
        }

        /// <summary>
        /// 現在表示しているWindowをすべて非表示にする
        /// </summary>
        public void AllCloseWindow()
        {
            try
            {
                for (int index = 0; index < windowList.Count; index++)
                {
                    if (windowList[index].IsOpne)
                        CloseWindow(windowList[index]);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("WindowManager::AllCloseWindow : windowList is null");
            }

        }
    }
}
