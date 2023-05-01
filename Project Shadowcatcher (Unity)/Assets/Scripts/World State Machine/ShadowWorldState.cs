using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWorldState : WorldBlankState
{
    public override void EnterState(WorldStateManager context)
    {
        context.shadowWorldPostProcessing.SetActive(true);
        context.ShadowsVisible(true);
        context.StartCoroutine(context.DrainBattery());
        context.StartCoroutine(context.CheckForShadows());

        // DANIEL: Switch BGM to Shadow World Variant here
        // DANIEL: This will also be the moment the firefly buddy uses it's ability 
    }
}
