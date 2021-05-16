using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : CharacterObject
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.SetHoldInputCallback(KeyCode.UpArrow, HoldInputUpArrow);
        InputManager.Instance.SetHoldInputCallback(KeyCode.DownArrow, HoldInputDownArrow);
        InputManager.Instance.SetHoldInputCallback(KeyCode.LeftArrow, HoldInputLeftArrow);
        InputManager.Instance.SetHoldInputCallback(KeyCode.RightArrow, HoldInputRightArrow);

        InputManager.Instance.SetHoldInputCallback(KeyCode.Q, PickUpFocusItem);

        InputManager.Instance.SetHoldInputCallback(KeyCode.A, ChantPyro);
        InputManager.Instance.SetHoldInputCallback(KeyCode.W, ChantAero);
        InputManager.Instance.SetHoldInputCallback(KeyCode.S, ChantHydro);
        InputManager.Instance.SetHoldInputCallback(KeyCode.D, ChantGeo);

        InputManager.Instance.SetDownInputCallback(KeyCode.R, DownInputAttackButton);
        InputManager.Instance.SetUpInputCallback(KeyCode.R, UpInputAttackButton);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

#region Input API
    void HoldInputUpArrow()
    {
        characterData.moveDirection.y = 1.0f;
    }

    void HoldInputDownArrow()
    {
        characterData.moveDirection.y = -1.0f;
    }

    void HoldInputLeftArrow()
    {
        characterData.moveDirection.x = -1.0f;
    }

    void HoldInputRightArrow()
    {
        characterData.moveDirection.x = 1.0f;
    }

    void PickUpFocusItem()
    {
        if (characterData.FocusItemObject == null)
        {
            return;
        }

        if (characterData.FocusItemObject.tag == "Mana")
        {
            PickUpManaItem();
        }
    }

    void PickUpManaItem()
    {
        ManaObject targetMana = characterData.FocusItemObject.GetComponent<ManaObject>();
        Define.Elements.TYPE targetType = targetMana.GetElementType();

        if (characterData.CanPickUpMana(targetType) == false)
        {
            return;
        }

        targetMana.PickUp();

        characterData.AddPossessionMana(targetType, 1);
    }

    void ChantPyro()
    {
        if (characterData.CanChantMana(Define.Elements.TYPE.PYRO) == false)
        {
            return;
        }

        Debug.Log("ChantPyro");
        characterData.AddChantingMana(Define.Elements.TYPE.PYRO);
    }

    void ChantAero()
    {
        if (characterData.CanChantMana(Define.Elements.TYPE.AERO) == false)
        {
            return;
        }

        Debug.Log("ChantAero");
        characterData.AddChantingMana(Define.Elements.TYPE.AERO);
    }

    void ChantHydro()
    {
        if (characterData.CanChantMana(Define.Elements.TYPE.HYDRO) == false)
        {
            return;
        }

        Debug.Log("ChantHydro");
        characterData.AddChantingMana(Define.Elements.TYPE.HYDRO);
    }

    void ChantGeo()
    {
        if (characterData.CanChantMana(Define.Elements.TYPE.GEO) == false)
        {
            return;
        }

        Debug.Log("ChantGeo");
        characterData.AddChantingMana(Define.Elements.TYPE.GEO);
    }

    void DownInputAttackButton()
    {
        Debug.Log("DownInputAttackButton");
        characterData.SetTargetingAttackEnabled(true);
    }

    void UpInputAttackButton()
    {
        Debug.Log("UpInputAttackButton");
        characterData.Attack();
    }
    #endregion
}
