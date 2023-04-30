using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovementState : ShadowBaseState
{
    public override void EnterState(ShadowStateManager context)
    {
        context.shadowMovement.movementAllowed = true;
    }

}
