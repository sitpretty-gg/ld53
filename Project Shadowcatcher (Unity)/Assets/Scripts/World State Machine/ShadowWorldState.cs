using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWorldState : WorldBlankState
{
    public override void EnterState(WorldStateManager context)
    {
        MusicState = "shadowSight";
        context.shadowWorldPostProcessing.SetActive(true);
        context.StartCoroutine(context.ShadowWorldTimer());
        context.ShadowsVisible(true);

        // DANIEL: Switch BGM to Shadow World Variant here
        // DANIEL: This will also be the moment the firefly buddy uses it's ability 
    }
}
