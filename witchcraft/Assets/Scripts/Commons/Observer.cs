using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    protected List<IObserver> _listeners = new List<IObserver>();
    
    // Start is called before the first frame update
    void Start()
    {
        Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()
    {
        _listeners.Clear();
    }

    public void AddListener(IObserver listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(IObserver listener)
    {
        int length = _listeners.Count;
        for(int i = 0; i < length; i++) 
        {
            IObserver entry = _listeners[i];
            if(entry == listener) 
            {
                _listeners.RemoveAt(i);
                break;
            }
        }
    }

    protected void NotifyEvent(string eventName)
    {
        int length = _listeners.Count;
        for(int i = 0; i < length; i++)
        {
            IObserver entry = _listeners[i];
            Type type = entry.GetType();
            MethodInfo methodInfo = type.GetMethod("ReceiveEvent", new Type[] {typeof(string)});
            if(methodInfo != null)
            {
                methodInfo.Invoke(entry, new object[]{eventName});
            }
            else
            {
                Debug.Log(eventName + " is not exist event method.");
            }
        }
    }
}
