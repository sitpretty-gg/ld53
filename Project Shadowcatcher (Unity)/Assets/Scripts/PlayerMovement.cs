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
    Backpack backpack;

    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;
    [SerializeField] Sprite northSprite;
    [SerializeField] Sprite southSprite;

    Vector2 input = new Vector2();
    [SerializeField] float moveSpeed;

    //bool lastMoveNorth;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        fxManager = FindObjectOfType<FXManager>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dragonfly = GetComponentInChildren<Dragonfly>();
        backpack = FindObjectOfType<Backpack>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //backpack.SetElementVisiblity(lastMoveNorth);
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
            fxManager.PlaySkate();

            if (input.x == 1)
            {
                SetSkating("isRunningHorizontal", true);
            }

            else if (input.x == -1)
            {
                SetSkating("isRunningHorizontal", true);
            }

            else if (input.y == 1)
            {
                SetSkating("isRunningNorth", true);
            }

            else if (input.y == -1)
            {
                SetSkating("isRunningSouth", true);
            }
        }

        else
        {
            spriteRenderer.flipX = false;
            SetSkating("null", false);
            // DANIEL: Movement sounds to turn off here
            fxManager.StopSkate();
        }

        if (input.x < 0)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = leftSprite;
            dragonfly.SetLocalPosition(dragonfly.eastV3);
        }

        else if (input.x > 0)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.sprite = rightSprite;
            dragonfly.SetLocalPosition(dragonfly.westV3);
        }

        else if (input.y > 0)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = northSprite;
            dragonfly.SetLocalPosition(dragonfly.southV3);
        }

        else if (input.y < 0)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = southSprite;
            dragonfly.SetLocalPosition(dragonfly.northV3);
        }
    }

    void SetSkating(string parameter, bool setter)
    {

        // if we don't have anything, reset all
        if (parameter == "null")
        {
            myAnimator.SetBool("isRunningNorth", setter);
            myAnimator.SetBool("isRunningSouth", setter);
            myAnimator.SetBool("isRunningHorizontal", setter);
        }

        // otherwise set the given parameter through the setter
        else
        {
            myAnimator.SetBool(parameter, setter);
        }
    }
}
