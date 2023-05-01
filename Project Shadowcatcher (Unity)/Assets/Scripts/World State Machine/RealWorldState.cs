using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealWorldState : WorldBlankState
{
    
    public override void EnterState(WorldStateManager context)
    {
        MusicState = "overWorld";
        context.shadowWorldPostProcessing.SetActive(false);

        context.ShadowsVisible(false);
        context.ResetAllWithinCapRange();
    }
}
