using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    WorldStateManager worldStateManager;
    Shadow shadow;
    PlayerMovement playerMovement;
    CanvasManager canvasManager;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        shadow = FindObjectOfType<Shadow>();
        canvasManager = FindObjectOfType<CanvasManager>();
        worldStateManager = FindObjectOfType<WorldStateManager>();
    }

    void OnMove(InputValue input)
    {
        playerMovement.SetInput(input.Get<Vector2>());
    }

    void OnViewShadowRealm(InputValue input)
    {
        worldStateManager.SwitchState(worldStateManager.shadowWorldState);
        shadow.AttemptCapture();
    }

    void OnTestSlider(InputValue input)
    {
        if (input.isPressed)
        {

            canvasManager.UpdateSlider(canvasManager.slider.value - 0.1f);
        }
    }

    void OnTestTMPro(InputValue input)
    {
        if (input.isPressed)
        {
            canvasManager.UpdateTMPro();
        }
    }
}
