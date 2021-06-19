using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class InputDefine
{
    // Button
    public const string BUTTON_A = "A_Button";
    public const string BUTTON_B = "B_Button";
    public const string BUTTON_X = "X_Button";
    public const string BUTTON_Y = "Y_Button";
    public const string BUTTON_L = "L_Button";
    public const string BUTTON_R = "R_Button";
    public const string BUTTON_VIEW = "View_Button";
    public const string BUTTON_MENU = "Menu_Button";

    // StickInput
    public const string STICK_L = "L_Stick";
    public const string STICK_R = "R_Stick";
    public const string D_PAD = "DPad";
    // TriggerInput
    public const string TRIGGER_L = "L_Trigger";
    public const string TRIGGER_R = "R_Trigger";
}


public class InputManager : SingletonMonoBehaviour<InputManager>
{
    Dictionary<KeyCode, List<Action>> upInputCallbackTable = new Dictionary<KeyCode, List<Action>>();

    Dictionary<KeyCode, List<Action>> downInputCallbackTable = new Dictionary<KeyCode, List<Action>>();

    Dictionary<KeyCode, List<Action>> holdInputCallbackTable = new Dictionary<KeyCode, List<Action>>();

    Dictionary<string, List<Action<Vector2>>> stickInputCallbackTable = new Dictionary<string, List<Action<Vector2>>>();

    Dictionary<string, List<Action<float>>> triggerInputCallbackTable = new Dictionary<string, List<Action<float>>>();

    /// <summary>
    /// アップデート
    /// </summary>
    void Update()
    {
        foreach (var code in upInputCallbackTable)
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

        foreach (var code in stickInputCallbackTable)
        {
            string stickHorizontalAxis = code.Key + "_H";
            string stickVerticalAxis = code.Key + "_V";

            float horizontal = Input.GetAxis(stickHorizontalAxis);
            float vertical = Input.GetAxis(stickVerticalAxis);

            Vector2 vec = new Vector2(horizontal, vertical);

            for (int i = 0; i < code.Value.Count; i++)
            {
                code.Value[i]?.Invoke(vec);
            }
        }

        foreach (var code in triggerInputCallbackTable)
        {
            float triggerValue = Input.GetAxis(code.Key);

            for (int i = 0; i < code.Value.Count; i++)
            {
                code.Value[i]?.Invoke(triggerValue);
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
        }
        holdInputCallbackTable[code].Add(callback);
    }

    /// <summary>
    /// ボタンを離したときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetUpInputCallback(String code, Action callback)
    {
        SetUpInputCallback(SetKeyCode(code), callback);
    }

    /// <summary>
    /// ボタンを押したときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetDownInputCallback(String code, Action callback)
    {
        SetDownInputCallback(SetKeyCode(code), callback);
    }

    /// <summary>
    /// ボタンを押しているときのイベント登録
    /// </summary>
    /// <param name="code">キーコード</param>
    /// <param name="callback">コールバック</param>
    public void SetHoldInputCallback(String code, Action callback)
    {
        SetHoldInputCallback(SetKeyCode(code), callback);
    }


    public void SetStickInputCallback(string code, Action<Vector2> callback)
    {
        if (!stickInputCallbackTable.ContainsKey(code))
        {
            stickInputCallbackTable.Add(code, new List<Action<Vector2>>());
        }
        stickInputCallbackTable[code].Add(callback);
    }

    public void SetTriggerInputCallbck(string code, Action<float> callback)
    {
        if (!triggerInputCallbackTable.ContainsKey(code))
        {
            triggerInputCallbackTable.Add(code, new List<Action<float>>());
        }
        triggerInputCallbackTable[code].Add(callback);
    }

    /// <summary>
    /// 文字列で受け取った
    /// </summary>
    /// <param name="codeStr">key文字列</param>
    /// <returns>keycode</returns>
    KeyCode SetKeyCode(string codeStr)
    {
        switch(codeStr)
        {
            case InputDefine.BUTTON_A:
                return KeyCode.JoystickButton0;
            case InputDefine.BUTTON_B:
                return KeyCode.JoystickButton1;
            case InputDefine.BUTTON_X:
                return KeyCode.JoystickButton2;
            case InputDefine.BUTTON_Y:
                return KeyCode.JoystickButton3;
            case InputDefine.BUTTON_L:
                return KeyCode.JoystickButton4;
            case InputDefine.BUTTON_R:
                return KeyCode.JoystickButton5;
            case InputDefine.BUTTON_VIEW:
                return KeyCode.JoystickButton6;
            case InputDefine.BUTTON_MENU:
                return KeyCode.JoystickButton7;
            default:
                return KeyCode.None;
        }
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
    /// upInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="code">登録されているキーコード</param>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveUpInput(string code, Action callback)
    {
        RemoveUpInput(SetKeyCode(code), callback);
    }

    /// <summary>
    /// downInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="code">登録されているキーコード</param>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveDownInput(string code, Action callback)
    {
        RemoveDownInput(SetKeyCode(code), callback);
    }

    /// <summary>
    /// holdInputに登録されているイベントのリムーブを行う
    /// </summary>
    /// <param name="code">登録されているキーコード</param>
    /// <param name="callback">登録されているコールバック</param>
    public void RemoveHoldInput(string code, Action callback)
    {
        RemoveHoldInput(SetKeyCode(code), callback);
    }

    public void RemoveStickInput(string code, Action<Vector2> callback)
    {
        stickInputCallbackTable[code].Remove(callback);
    }

    public void RemoveTriggerInput(string code, Action<float> callback)
    {
        triggerInputCallbackTable[code].Remove(callback);
    }

    //public void RemoveTriggerInput()

    /// <summary>
    /// 登録してあるイベントを全て削除
    /// </summary>
    public void AllClearInput()
    {
        upInputCallbackTable.Clear();
        downInputCallbackTable.Clear();
        holdInputCallbackTable.Clear();
        stickInputCallbackTable.Clear();
        triggerInputCallbackTable.Clear();
    }
}
