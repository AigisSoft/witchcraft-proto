using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : Object
{
    protected Character characterData;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        characterData = this.gameObject.GetComponent<Character>();
        characterData.FocusItemObject = null;
        characterData.AddListener(this);
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

        Vector2 moveDirection = characterData.moveDirection;
        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            characterData.CurrentMoveSpeed = characterData.CurrentMoveSpeed * characterData.moveDecelerate;
        }
        else
        {
            characterData.CurrentMoveSpeed += characterData.moveAcceleration;
        }

        rigidbody.MovePosition(rigidbody.position + (transform.forward * characterData.CurrentMoveSpeed * Time.deltaTime));
    }

    void Rotation()
    {
        Vector2 moveDirection = characterData.moveDirection;

        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            return;
        }

        float direction = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, direction, 0), characterData.moveRotationSpeed * Time.deltaTime);
        moveDirection.x = 0f;
        moveDirection.y = 0f;

        characterData.moveDirection = moveDirection;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mana")
        {
            characterData.FocusItemObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (characterData.FocusItemObject == other.gameObject)
        {
            characterData.FocusItemObject = null;
        }
    }

    #region Observer EVENT
    public void EVENT_setFocusItemObject()
    {
        if (characterData.FocusItemObject != null)
        {
            Debug.Log("FocusItemObject = " + characterData.FocusItemObject.tag);
        }
        else
        {
            Debug.Log("FocusItemObject = null");
        }
    }
    #endregion
}
