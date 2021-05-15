using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Observer
{
    public float maxMoveSpeed = 5.0f;
    public float minMoveSpeed = 0.1f;
    protected float currentMoveSpeed = 0.0f;
    public float CurrentMoveSpeed
    {
        get
        {
            return currentMoveSpeed;
        }
        set
        {
            currentMoveSpeed = value;
            if (currentMoveSpeed >= maxMoveSpeed)
            {
                currentMoveSpeed = maxMoveSpeed;
            }
            else if (minMoveSpeed > currentMoveSpeed)
            {
                currentMoveSpeed = 0;
            }
        }
    }

    public float moveAcceleration = 2.0f;
    public float moveDecelerate = 0.5f;
    public float moveRotationSpeed = 3.0f;
    public Vector2 moveDirection = new Vector2(0, 0);

    protected GameObject focusItemObject;
    public GameObject FocusItemObject
    {
        get
        {
            return focusItemObject;
        }
        set
        {
            focusItemObject = value;
            NotifyEvent("EVENT_setFocusItemObject");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
