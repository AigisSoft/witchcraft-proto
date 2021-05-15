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

        InputManager.Instance.SetHoldInputCallback(KeyCode.A, PickUpFocusItem);
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
        if (characterData.FocusItemObject)
        {
            characterData.FocusItemObject.GetComponent<ManaObject>().PickUp();
        }
    }
#endregion
}
