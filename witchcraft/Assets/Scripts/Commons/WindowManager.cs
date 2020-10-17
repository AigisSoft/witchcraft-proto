using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

namespace Commons
{
    public enum WindowType
    {//TODO:スネークに変更数
        None,
        MessageDialog,
    }


    //TODO:AllClose的な関数の追加
    //TODO:Reopen(再表示)的な機能の追加、Openないで判断


    public class WindowManager : Singleton<WindowManager>
    {
        static private List<Window> windowList = null;
        static Canvas canvas = null;

        private WindowFactory factory = null;
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
                        _wid.Close();
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

            factory = WindowFactory.Instance;
        }

        //TODO:インスタンス生成を外で引数で渡す
        //Create→Open 
        public MessageDialog CreateMessageDialog(string i_message)
        {
            GameObject _obj = factory.MessageDialogCreate();
            if(_obj == null)
            {
               return null;
            }

            MessageDialog _md = _obj.AddComponent<MessageDialog>();

            _md.Message = i_message;

            if(!_md.Initialize())
            {
                factory.DestroyWindow(_obj);
                return null;
            }

            windowList.Add(_md);
            return _md;
        }

        /// <summary>
        /// Windowの削除
        /// </summary>
        /// <param name="i_window"></param>
        public void DestroyWindow(Window i_window)
        {
            if(i_window == null)
            {
                return;
            }

            i_window.Close();
            windowList.Remove(i_window);
            factory.DestroyWindow(i_window.gameObject);
        }
    }
}
