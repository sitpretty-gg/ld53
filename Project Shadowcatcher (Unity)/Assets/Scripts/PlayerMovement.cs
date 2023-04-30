using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{

    Animator myAnimator;
    private FXManager fxManager;
    private AudioSource audioSource;
    public AudioClip currentClip;

    Vector2 input = new Vector2();
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        fxManager = FindObjectOfType<FXManager>();
        audioSource = GetComponent<AudioSource>();
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
            Debug.Log("SkateSoundfromPlayerMovement");
        }

        else
        {
            SetSkating(false);
            // DANIEL: Movement sounds to turn off here
            fxManager.StopSkate();
            Debug.Log("stopSkateSound");
            
        }
    }

    void SetSkating(bool setter)
    {
        myAnimator.SetBool("isRunning", setter);
    }
}
