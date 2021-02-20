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
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

#region Input API
    void HoldInputUpArrow()
    {
        moveDirection.y = 1.0f;
    }

    void HoldInputDownArrow()
    {
        moveDirection.y = -1.0f;
    }

    void HoldInputLeftArrow()
    {
        moveDirection.x = -1.0f;
    }

    void HoldInputRightArrow()
    {
        moveDirection.x = 1.0f;
    }
    #endregion
}
