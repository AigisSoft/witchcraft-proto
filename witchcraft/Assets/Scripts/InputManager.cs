using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : SingletonMonoBehaviour<InputManager>
{
    Dictionary<KeyCode, Action> upInput = new Dictionary<KeyCode, Action>();

    Dictionary<KeyCode, Action> downInput = new Dictionary<KeyCode, Action>();

    Dictionary<KeyCode, Action> holdInput = new Dictionary<KeyCode, Action>();


    /// <summary>
    /// アップデート
    /// </summary>
    void Update()
    {
        foreach(var code in upInput)
        {
            if (Input.GetKeyUp(code.Key))
            {
                code.Value?.Invoke();
            }
        }

        foreach (var code in downInput)
        {
            if (Input.GetKeyDown(code.Key))
            {
                code.Value?.Invoke();
            }
        }

        foreach (var code in holdInput)
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
    public void SetUpInput(KeyCode code, Action callback)
    {
        if (!upInput.ContainsKey(code))
        {
            upInput.Add(code, null);
        }
        upInput[code] += callback;
    }

    /// <summary>
    /// ボタンを押したときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetDownInput(KeyCode code, Action callback)
    {
        if (!downInput.ContainsKey(code))
        {
            downInput.Add(code, null);
        }
        downInput[code] += callback;
    }

    /// <summary>
    /// ボタンを押しているときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetHoldInput(KeyCode code, Action callback)
    {
        if (!holdInput.ContainsKey(code))
        {
            holdInput.Add(code, null);
        }
        holdInput[code] += callback;
    }
}
