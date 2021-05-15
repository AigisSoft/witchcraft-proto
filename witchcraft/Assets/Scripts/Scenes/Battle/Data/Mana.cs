using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : Observer
{
    Define.Elements.TYPE elementType;
    public Define.Elements.TYPE ElementType
    {
        get
        {
            return elementType;
        }
        set
        {
            elementType = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        elementType = Define.Elements.TYPE.PYRO;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
