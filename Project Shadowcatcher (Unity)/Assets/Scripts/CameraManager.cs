using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform target;
    Vector3 offset = new Vector3(0, 0, -10);

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    public bool lookAroundInputTriggered;

    [SerializeField] int lookAroundPadding;

    private void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3();
        newPosition.x = Mathf.Clamp(target.position.x, minX, maxX);
        newPosition.y = Mathf.Clamp(target.position.y, minY, maxY);
        newPosition.z = -10;
        transform.position = newPosition;
    }
}
