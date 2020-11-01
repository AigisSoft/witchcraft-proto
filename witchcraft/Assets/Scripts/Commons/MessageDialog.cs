﻿using Commons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDialog : Commons.Window
{
    private string message = string.Empty;
    public string Message
    {
        get { return message; }
        set { message = value; }
    }

    private Text messageText = null;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <returns></returns>
    public override bool Initialize()
    {
        if(!base.Initialize())
        {
            return false;
        }

        messageText = this.transform.Find("Message").gameObject.GetComponent<Text>();
        if(messageText == null)
        {
            return false;
        }

        UpdateMessage();
        return true;
    }

    public override void OnOpen()
    {
        base.OnOpen();
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    /// <summary>
    /// メッセージ更新処理
    /// </summary>
    public void UpdateMessage()
    {
        messageText.text = message;
    }
}
