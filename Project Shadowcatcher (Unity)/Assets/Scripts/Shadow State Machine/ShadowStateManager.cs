using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowStateManager : MonoBehaviour
{

    SpriteRenderer mySpriteRenderer;
    GameManager gameManager;
    PlayerMovement player;
    FXManager fxManager;
    NPCInteract npcInteract;

    [SerializeField] public Sprite realWorldSprite;
    [SerializeField] public Sprite shadowWorldSprite;

    ShadowBaseState currentState;
    public ShadowIdleState idleState = new ShadowIdleState();
    public ShadowMovementState movementState = new ShadowMovementState();

    [SerializeField] public float radius;
    public LayerMask shadowMask;

    [SerializeField] Vector3 goalPos;


    public bool isWithinCapRange = false;
    public bool captured = false;

    public ShadowMovement shadowMovement;


    // Start is called before the first frame update
    void Start()
    {
        npcInteract = GetComponentInParent<NPCInteract>();
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        shadowMovement = GetComponent<ShadowMovement>();
        // Note for future Goji, this is "InChildren" so we can offset the sprite for
        // lighting angle. Please don't forget (again)
        player = FindObjectOfType<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();
        fxManager = FindObjectOfType<FXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeVisible(bool setter)
    {
        mySpriteRenderer.enabled = setter;
    }

    public void SwitchState(ShadowBaseState newState)
    {
        if (!captured)
        {
            currentState = newState;
            newState.EnterState(this);
        }
    }

    public void CheckForHuman()
    {
        Vector3 roundedPosition = new Vector3();

        roundedPosition.x = Mathf.RoundToInt(transform.position.x);
        roundedPosition.y = Mathf.RoundToInt(transform.position.y);

        //if ((roundedPosition == goalPos) && (isWithinCapRange = true))

        if (roundedPosition == goalPos)
        {
            // and...
            if (isWithinCapRange)
            {
                Capture(goalPos);
            }
        }
    }

    private void Capture(Vector3 position)
    {
        mySpriteRenderer.sprite = realWorldSprite;
        mySpriteRenderer.enabled = true;
        transform.position = position;
        captured = true;

        gameManager.UpdateCapturedGhosts(1);
        npcInteract.SetText(npcInteract.shadowText);

        // DANIEL: Potentially a sound effect for restoring a shadow here?
        fxManager.PlayShadowAttach();
    }

    public void CheckWithinCapRange()
    {
        // Create a circle at the player, with a radius of x and check for objects on the shadowMask

        Collider2D[] shadowsWithinRange = Physics2D.OverlapCircleAll(player.transform.position, radius, shadowMask);
        {
            if (shadowsWithinRange.Length != 0)
            {
                Debug.Log("A SHADOW WAS FOUND");
                foreach (Collider2D shadowWithinRange in shadowsWithinRange)
                {
                    var instance = shadowWithinRange.GetComponent<ShadowStateManager>();
                    instance.isWithinCapRange = true;
                    fxManager.PlayShadowAttach();
                }
            }
        }
    }

    public void SetShadowSprite(Sprite setter)
    {
        mySpriteRenderer.sprite = setter;
    }
}
