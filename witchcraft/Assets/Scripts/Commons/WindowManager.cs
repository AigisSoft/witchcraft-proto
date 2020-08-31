using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

namespace Commons
{
    public enum WindowType
    {
        none,
        MessageDialog,
    }

    public enum WINDOW_ERROR
    {
        NONE = 0x0000,

        CREATE_ERROR = 0x0100,
    }

    public class WindowManager : Singleton<WindowManager>
    {
        static private List<Window> windowList = null;
        static Canvas canvas = null;

        private WindowFactory factory = null;

        //初期化
        public override void Initialize()
        {
            windowList = new List<Window>();
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

            factory = WindowFactory.Instance;
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        public MessageDialog MessageDialogCreate(string i_message)
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

        //解放処理
        ~WindowManager()
        {
            if(windowList != null)
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
    }
}
