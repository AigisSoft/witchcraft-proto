using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Observer
{
    protected float maxMoveSpeed = 5.0f;
    protected float minMoveSpeed = 0.1f;
    protected float currentMoveSpeed = 0.0f;
    protected float CurrentMoveSpeed
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

    protected float moveAcceleration = 2.0f;
    protected float moveDecelerate = 0.5f;
    protected float moveRotationSpeed = 3.0f;
    protected Vector2 moveDirection = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
