using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    Dictionary<KeyCode, List<Action>> upInputCallbackTable = new Dictionary<KeyCode, List<Action>>();

    Dictionary<KeyCode, List<Action>> downInputCallbackTable = new Dictionary<KeyCode, List<Action>>();

    Dictionary<KeyCode, List<Action>> holdInputCallbackTable = new Dictionary<KeyCode, List<Action>>();


    /// <summary>
    /// アップデート
    /// </summary>
    void Update()
    {
        foreach(var code in upInputCallbackTable)
        {
            if (Input.GetKeyUp(code.Key))
            {
                for (int i = 0; i < code.Value.Count; i++)
                {
                    code.Value[i]?.Invoke();
                }
            }
        }

        foreach (var code in downInputCallbackTable)
        {
            if (Input.GetKeyDown(code.Key))
            {
                for (int i = 0; i < code.Value.Count; i++)
                {
                    code.Value[i]?.Invoke();
                }
            }
        }

        foreach (var code in holdInputCallbackTable)
        {
            if (Input.GetKey(code.Key))
            {
                for (int i = 0; i < code.Value.Count; i++)
                {
                    code.Value[i]?.Invoke();
                }
            }
        }
    }

    /// <summary>
    /// ボタンを離したときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetUpInputCallback(KeyCode code, Action callback)
    {
        if (!upInputCallbackTable.ContainsKey(code))
        {
            upInputCallbackTable.Add(code, new List<Action>());
        }
        upInputCallbackTable[code].Add(callback);
    }

    /// <summary>
    /// ボタンを押したときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetDownInputCallback(KeyCode code, Action callback)
    {
        if (!downInputCallbackTable.ContainsKey(code))
        {
            downInputCallbackTable.Add(code, new List<Action>());
        }
        downInputCallbackTable[code].Add(callback);
    }

    /// <summary>
    /// ボタンを押しているときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetHoldInputCallback(KeyCode code, Action callback)
    {
        if (!holdInputCallbackTable.ContainsKey(code))
        {
            holdInputCallbackTable.Add(code, new List<Action>());
            return;
        }
        holdInputCallbackTable[code].Add(callback);
    }

    /// <summary>
    /// upInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="code">登録されているキーコード</param>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveUpInput(KeyCode code, Action callback)
    {
        upInputCallbackTable[code].Remove(callback);
    }

    /// <summary>
    /// downInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="code">登録されているキーコード</param>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveDownInput(KeyCode code, Action callback)
    {
        downInputCallbackTable[code].Remove(callback);
    }

    /// <summary>
    /// holdInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="code">登録されているキーコード</param>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveHoldInput(KeyCode code, Action callback)
    {
        holdInputCallbackTable[code].Remove(callback);
    }

    /// <summary>
    /// 登録してあるイベントを全て削除
    /// </summary>
    public void ClearInput()
    {
        upInputCallbackTable.Clear();
        downInputCallbackTable.Clear();
        holdInputCallbackTable.Clear();
    }
}
