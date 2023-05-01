using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    GameManager gameManager;
    PlayerMovement player;
    FXManager fxManager;
    

    [SerializeField] public Sprite realWorldSprite;
    [SerializeField] public Sprite shadowWorldSprite;

    [SerializeField] public float radius;
    public LayerMask shadowMask;

    Vector3 endPos = new Vector3(-5, 1, 0);
    Vector3 goalPos = new Vector3 (2, 1, 0);
    [SerializeField] float speed;

    public bool isWithinCapRange = false;
    public bool captured = false;

    private void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();
        fxManager = FindObjectOfType<FXManager>();
    }

    void Update()
    {
        var interval = speed * Time.deltaTime;

        if (captured != true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, interval);
            CheckForHuman();
        }
    }

    public void MakeVisible(bool setter)
    {
        mySpriteRenderer.enabled = setter;
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
        fxManager.PlayShadowAttach();

        // DANIEL: Potentially a sound effect for restoring a shadow here?


    }

    public void CheckWithinCapRange()
    {
        Collider2D[] shadowsWithinRange = Physics2D.OverlapCircleAll(player.transform.position, radius, shadowMask);
        {
            if (shadowsWithinRange.Length != 0)
            {
                foreach (Collider2D shadowWithinRange in shadowsWithinRange)
                {
                    Debug.Log("we found a ghost?");
                    var instance = shadowWithinRange.GetComponent<Shadow>();
                    instance.isWithinCapRange = true;
                }
            }
        }
    }

    public void SetShadowSprite(Sprite setter)
    {
        mySpriteRenderer.sprite = setter;
    }
}
