using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Observer
{
    Define.Elements.TYPE elementType;

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
