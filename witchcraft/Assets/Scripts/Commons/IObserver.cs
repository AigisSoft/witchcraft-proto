using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class IObserver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveEvent(string eventName)
    {
        Type type = this.GetType();
        MethodInfo methodInfo = type.GetMethod(eventName);
        if(methodInfo != null)
        {
            methodInfo.Invoke(this, null);
        }
        else
        {
            Debug.Log(eventName + " is not exist event method.");
        }
    }
}
