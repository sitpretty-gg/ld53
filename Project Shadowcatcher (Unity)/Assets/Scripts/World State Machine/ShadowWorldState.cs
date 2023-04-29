using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWorldState : WorldBlankState
{
    public override void EnterState(WorldStateManager context)
    {
        context.shadowWorldPostProcessing.SetActive(true);
        context.StartCoroutine(context.ShadowWorldTimer());
        context.ShadowsVisible(true);
    }
}
