using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath : MonoBehaviour
{
    [SerializeField] Vector3[] path;

    public Vector3[] GetPath()
    {
        return path;
    }
}
