using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : Object
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

    protected GameObject focusItemObject;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        focusItemObject = null;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Move();
        Rotation();
        base.Update();
    }

    void Move()
    {
        if (rigidbody == null)
        {
            Debug.LogError(this.gameObject + "にRigidbodyがアタッチされていません");
            return;
        }

        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            CurrentMoveSpeed = currentMoveSpeed * moveDecelerate;
        }
        else
        {
            CurrentMoveSpeed += moveAcceleration;
        }

        rigidbody.MovePosition(rigidbody.position + (transform.forward * currentMoveSpeed * Time.deltaTime));
    }

    void Rotation()
    {
        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            return;
        }

        float direction = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, direction, 0), moveRotationSpeed * Time.deltaTime);
        moveDirection.x = 0f;
        moveDirection.y = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mana")
        {
            focusItemObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (focusItemObject == other.gameObject)
        {
            focusItemObject = null;
        }
    }
}
