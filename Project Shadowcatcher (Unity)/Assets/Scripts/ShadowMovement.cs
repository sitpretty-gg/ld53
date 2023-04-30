using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{

    // WHERE WE HANDLE OUR ROUTES AND OUR MOVEMENT THROUGH THE ROUTES WHEN CALLED

    public bool movementAllowed;


    [SerializeField] AIPath path;

    Vector3[] pathPositions;

    [SerializeField] float speed;
    ShadowStateManager shadowStateManager;
    [SerializeField] bool loopRoute;

    int currentTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        shadowStateManager = GetComponent<ShadowStateManager>();
        pathPositions = path.GetPath();
    }

    // Update is called once per frame
    void Update()
    {
        var interval = speed * Time.deltaTime;

        if (currentTarget == pathPositions.Length)
        {
            if (loopRoute)
            {
                currentTarget = 0;
            }

            else movementAllowed = false;
        }

        if (movementAllowed && GetComponent<ShadowStateManager>().captured == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pathPositions[currentTarget], interval);
            shadowStateManager.CheckForHuman();

            // if we arrive
            if (transform.position == pathPositions[currentTarget])
            {
                currentTarget++;
            }
        }
    }

}
