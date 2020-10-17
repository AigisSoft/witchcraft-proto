using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commons
{
    public class WindowFactory : MonoBehaviour
    {
        private GameObject MessageDialogObj;

        private List<GameObject> windowObjList = null;
        static private WindowFactory instance = null;
        static public WindowFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject("WindowFactory");
                    instance = obj.AddComponent<WindowFactory>();

                    instance.Initialize();
                }
                return instance;
            }
        }

        public void Initialize()
        {
            windowObjList = new List<GameObject>();
            if (!LoadPlefab())
                return;//Error

        }

        /// <summary>
        /// プレハブの読み込み処理
        /// </summary>
        /// <returns></returns>
        private bool LoadPlefab()
        {
            MessageDialogObj = (GameObject)Resources.Load("Prefabs/Window/MessageDialog");
            if (MessageDialogObj == null)
                return false;


            return true;
        }

        /// <summary>
        /// メッセージダイアログを生成
        /// </summary>
        /// <returns></returns>
        public GameObject MessageDialogCreate()
        {
            if(MessageDialogObj == null)
            {
                return null;
            }

            GameObject _obj = Instantiate(MessageDialogObj);
            if (_obj == null)
            {
                return null;
            }

            windowObjList.Add(_obj);
            return _obj;
        }

        /// <summary>
        /// Window削除
        /// </summary>
        /// <param name="i_destroyObj"></param>
        public void DestroyWindow(GameObject i_destroyObj)
        {
            int _index = windowObjList.IndexOf(i_destroyObj);
            if (_index == -1)
            {
                return;
            }

            Destroy(windowObjList[_index]);
            windowObjList.RemoveAt(_index);
        }
    }
}
