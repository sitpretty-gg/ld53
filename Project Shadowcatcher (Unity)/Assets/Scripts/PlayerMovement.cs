using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{

    Animator myAnimator;
    Dragonfly dragonfly;
    private FXManager fxManager;
    private AudioSource audioSource;
    public AudioClip currentClip;

    SpriteRenderer spriteRenderer;

    Vector2 input = new Vector2();
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        fxManager = FindObjectOfType<FXManager>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dragonfly = GetComponentInChildren<Dragonfly>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    public void Move()
    {
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x + input.x * moveSpeed * Time.deltaTime;
        newPos.y = transform.position.y + input.y * moveSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    public void SetInput(Vector2 alphaInput)
    {
        input = alphaInput;

        if (input.x != 0 || input.y != 0)
        {
            SetSkating(true);
            // DANIEL: Movement sounds to trigger here
            fxManager.PlaySkate();
        }

        else
        {
            SetSkating(false);
            // DANIEL: Movement sounds to turn off here
            fxManager.StopSkate();
        }

        if (input.x < 0)
        {
            spriteRenderer.flipX = true;
            
        }

        else
        {
            spriteRenderer.flipX = false;
        }

        if (input.x < 0)
        {
            dragonfly.SetLocalPosition(dragonfly.eastV3);
        }

        else if (input.x > 0)
        {
            dragonfly.SetLocalPosition(dragonfly.westV3);
        }

        else if (input.y > 0)
        {
            dragonfly.SetLocalPosition(dragonfly.southV3);
        }

        else if (input.y < 0)
        {
            dragonfly.SetLocalPosition(dragonfly.northV3);
        }
    }

    void SetSkating(bool setter)
    {
        myAnimator.SetBool("isRunning", setter);
    }
}
