using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class InputManager : MonoBehaviour
{
    public enum INPUT_TYPE
    {
        UP,
        DOWN
    }

    // 左スティック
    public event Action<float, float> OnLStickInput;

    // 右スティック
    public event Action<float, float> OnRStickInput;

    // D-Pad
    public event Action<float, float> OnDpadInput;

    // Lトリガー
    public event Action<float> OnLTriggerInput;

    // Rトリガー
    public event Action<float> OnRTriggerInput;

    // Aボタン
    public event Action<INPUT_TYPE> OnAButtonInput;

    // Bボタン
    public event Action<INPUT_TYPE> OnBButtonInput;

    // Xボタン
    public event Action OnXButtonInput;

    // Yボタン
    public event Action OnYButtonInput;

    // Lボタン
    public event Action OnLButtonInput;

    // Rボタン
    public event Action OnRButtonInput;

    // Viewボタン
    public event Action OnViewButtonInput;

    // Menuボタン
    public event Action OnMenuButtonInput;

    // Update is called once per frame
    void Update()
    {
        LStickInput();

        RStickInput();

        DPadInput();

        LTriggerInput();
        RTriggerInput();

        AButtonInput();
        BButtonInput();
        XButtonInput();
        YButtonInput();

        LButtonInput();
        RButtonInput();

        ViewButtonInput();
        MenuButtonInput();
    }

    /// <summary>
    /// Lスティック
    /// </summary>
    void LStickInput()
    {
        float dx = Input.GetAxis("L_Stick_H");
        float dy = Input.GetAxis("L_Stick_V");

        if (OnLStickInput != null)
        {
            OnLStickInput(dx, dy);
        }
    }

    /// <summary>
    /// Rスティック
    /// </summary>
    void RStickInput()
    {
        float dx = Input.GetAxis("R_Stick_H");
        float dy = Input.GetAxis("R_Stick_V");

        if (OnRStickInput != null)
        {
            OnRStickInput(dx, dy);
        }
    }

    /// <summary>
    /// Dパッド
    /// </summary>
    void DPadInput()
    {
        float dx = Input.GetAxisRaw("DPad_H");
        float dy = Input.GetAxisRaw("DPad_V");

        if (OnDpadInput != null)
        {
            OnDpadInput(dx, dy);
        }
    }

    /// <summary>
    /// Lトリガー
    /// </summary>
    void LTriggerInput()
    {
        float triggerLength = Input.GetAxis("L_Trigger");

        if (OnLTriggerInput != null)
        {
            OnLTriggerInput(triggerLength);
        }
    }

    /// <summary>
    /// Rトリガー
    /// </summary>
    void RTriggerInput()
    {
        float triggerLength = Input.GetAxis("R_Trigger");

        if (OnRTriggerInput != null)
        {
            OnRTriggerInput(triggerLength);
        }
    }

    /// <summary>
    /// Aボタン
    /// </summary>
    void AButtonInput()
    {
        if (Input.GetButtonDown("A_Button") && OnAButtonInput != null)
        {
            OnAButtonInput(INPUT_TYPE.DOWN);
        }
        else if (Input.GetButtonUp("A_Button") && OnAButtonInput != null)
        {
            OnAButtonInput(INPUT_TYPE.UP);
        }
    }

    /// <summary>
    /// Bボタン
    /// </summary>
    void BButtonInput()
    {
        if (Input.GetButtonDown("B_Button") && OnBButtonInput != null)
        {
            OnBButtonInput(INPUT_TYPE.DOWN);
        }
        else if (Input.GetButtonUp("B_Button") && OnBButtonInput != null)
        {
            OnBButtonInput(INPUT_TYPE.UP);
        }
    }

    /// <summary>
    /// Xボタン
    /// </summary>
    void XButtonInput()
    {

    }

    /// <summary>
    /// Yボタン
    /// </summary>
    void YButtonInput()
    {

    }

    /// <summary>
    /// Lボタン
    /// </summary>
    void LButtonInput()
    {

    }

    /// <summary>
    /// Rボタン
    /// </summary>
    void RButtonInput()
    {

    }

    /// <summary>
    /// Viewボタン
    /// </summary>
    void ViewButtonInput()
    {

    }

    /// <summary>
    /// Menuボタン
    /// </summary>
    void MenuButtonInput()
    {

    }
}
