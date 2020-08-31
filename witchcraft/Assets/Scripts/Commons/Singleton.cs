﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Singleton<T> where T: new()
{
    static protected T m_instance;

    static public T GetInstance()
    {
        if(m_instance == null)
        {
            m_instance = new T();
        }

        return m_instance;
    }

    public virtual void Initialize()
    {

    }
}