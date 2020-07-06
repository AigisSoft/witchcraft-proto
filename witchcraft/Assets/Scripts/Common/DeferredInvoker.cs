using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeferredInvoker
{
    List<Action> _entries = new List<Action>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    public void clear()
    {
        _entries.Clear();
    }

    // Update is called once per frame
    public void push(Action func)
    {
        _entries.Add(func);
    }

    // Update is called once per frame
    public bool resume()
    {
        if(_entries.Count == 0) {
            return false;
        }

        Action func = _entries[0];
        _entries.RemoveAt(0);
        func();

        return true;
    }
}