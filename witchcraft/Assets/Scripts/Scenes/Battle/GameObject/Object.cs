using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : IObserver
{
    protected new Rigidbody rigidbody;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            Debug.LogError(this.gameObject + "にRigidbodyがアタッチされていません");
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
}
