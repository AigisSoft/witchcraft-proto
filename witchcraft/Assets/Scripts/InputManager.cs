using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    Dictionary<KeyCode, Action> upInputCallbackTable = new Dictionary<KeyCode, Action>();

    Dictionary<KeyCode, Action> downInputCallbackTable = new Dictionary<KeyCode, Action>();

    Dictionary<KeyCode, Action> holdInputCallbackTable = new Dictionary<KeyCode, Action>();


    /// <summary>
    /// アップデート
    /// </summary>
    void Update()
    {
        foreach(var code in upInputCallbackTable)
        {
            if (Input.GetKeyUp(code.Key))
            {
                code.Value?.Invoke();
            }
        }

        foreach (var code in downInputCallbackTable)
        {
            if (Input.GetKeyDown(code.Key))
            {
                code.Value?.Invoke();
            }
        }

        foreach (var code in holdInputCallbackTable)
        {
            if (Input.GetKey(code.Key))
            {
                code.Value?.Invoke();
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
            upInputCallbackTable.Add(code, callback);
            return;
        }
        upInputCallbackTable[code] += callback;
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
            downInputCallbackTable.Add(code, callback);
            return;
        }
        downInputCallbackTable[code] += callback;
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
            holdInputCallbackTable.Add(code, callback);
            return;
        }
        holdInputCallbackTable[code] += callback;
    }

    /// <summary>
    /// upInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveUpInput(Action callback)
    {
        foreach(var code in upInputCallbackTable)
        {
            if (code.Value == callback)
            {
                upInputCallbackTable.Remove(code.Key);
                break;
            }
        }
    }

    /// <summary>
    /// downInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveDownInput(Action callback)
    {
        foreach (var code in downInputCallbackTable)
        {
            if (code.Value == callback)
            {
                downInputCallbackTable.Remove(code.Key);
                break;
            }
        }
    }

    /// <summary>
    /// holdInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveHoldInput(Action callback)
    {
        foreach (var code in holdInputCallbackTable)
        {
            if (code.Value == callback)
            {
                holdInputCallbackTable.Remove(code.Key);
                break;
            }
        }
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
