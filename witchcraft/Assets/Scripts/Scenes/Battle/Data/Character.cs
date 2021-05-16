using System;
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

    protected int[] possessionManaCountTable;
    protected int maxPossessionMana = 3;

    protected Define.Elements.TYPE?[] chantingManaCountTable;
    protected int maxChantingMana = 3;
    protected int currentChantIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        int length = Enum.GetNames(typeof(Define.Elements.TYPE)).Length;
        possessionManaCountTable = new int[length];
        for (int i = 0; i < length; i++)
        {
            possessionManaCountTable[i] = 0;
        }

        chantingManaCountTable = new Define.Elements.TYPE?[maxChantingMana];
        currentChantIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanPickUpMana(Define.Elements.TYPE elementType)
    {
        int index = (int)elementType;
        if (possessionManaCountTable[index] < maxPossessionMana)
        {
            return true;
        }

        return false;
    }

    public int GetPossessionMana(Define.Elements.TYPE elementType)
    {
        int index = (int)elementType;
        return possessionManaCountTable[index];
    }

    public void SetPossessionMana(Define.Elements.TYPE elementType, int count)
    {
        int index = (int)elementType;
        possessionManaCountTable[index] += count;

        if (maxPossessionMana < possessionManaCountTable[index])
        {
            possessionManaCountTable[index] = maxPossessionMana;
        }
        else if (possessionManaCountTable[index] < 0)
        {
            possessionManaCountTable[index] = 0;
        }

        NotifyEvent("EVENT_setPossessionMana");
    }

    public void AddPossessionMana(Define.Elements.TYPE elementType, int count)
    {
        int index = (int)elementType;
        int possession = possessionManaCountTable[index] + count;

        SetPossessionMana(elementType, possession);
    }

    public bool CanChantMana(Define.Elements.TYPE elementType)
    {
        if (maxChantingMana <= currentChantIndex)
        {
            return false;
        }

        int currentChantTargetMana = 0;
        for (int i = 0; i < maxChantingMana; i++)
        {
            if (chantingManaCountTable[i] == elementType)
            {
                currentChantTargetMana += 1;
            }
        }

        if (GetPossessionMana(elementType) < currentChantTargetMana + 1)
        {
            return false;
        }

        return true;
    }

    public void ClearChantingMana()
    {
        for (int i = 0; i < maxChantingMana; i++)
        {
            chantingManaCountTable[i] = null;
        }

        currentChantIndex = 0;
    }

    public void AddChantingMana(Define.Elements.TYPE elementType)
    {
        if (CanChantMana(elementType) == false)
        {
            return;
        }

        chantingManaCountTable[currentChantIndex] = elementType;

        currentChantIndex += 1;

        NotifyEvent("EVENT_addChantingMana");
    }

    public void SetTargetingAttackEnabled(bool enable)
    {
        NotifyEvent("EVENT_setTargetingAttackEnabled");
    }

    public void Attack()
    {
        SetTargetingAttackEnabled(false);
        ClearChantingMana();
        NotifyEvent("EVENT_attack");
    }
}
