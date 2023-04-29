using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{

    Animator myAnimator;

    Vector2 input = new Vector2();
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
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
            SetRunning(true);
        }

        else { SetRunning(false); }
    }

    void SetRunning(bool setter)
    {
        myAnimator.SetBool("isRunning", setter);
    }
}
