using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldBlankState 
{
    public string MusicState;
    public abstract void EnterState(WorldStateManager context);

}
