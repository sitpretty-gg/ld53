using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    WorldStateManager worldStateManager;
    [SerializeField] ShadowStateManager [] shadows;
    PlayerMovement playerMovement;
    PlayerInteractables playerInteractables;
    CanvasManager canvasManager;
    CameraManager cameraManager;
    private FXManager fxManager;

    bool inputLocked = false;
    Vector2 lastInput = new Vector2();

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerInteractables = FindObjectOfType<PlayerInteractables>();
        canvasManager = FindObjectOfType<CanvasManager>();
        worldStateManager = FindObjectOfType<WorldStateManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        fxManager = FindObjectOfType<FXManager>();
    }

    private void Update()
    {
        if (!inputLocked)
        {
            playerMovement.SetInput(lastInput);
            inputLocked = true;
        }
        else
        {
            // Check if the last input has been released
            var devices = InputSystem.devices;
            foreach (var device in devices)
            {
                if (device is Keyboard keyboard)
                {
                    if (!keyboard.anyKey.isPressed)
                    {
                        // Unlock input
                        playerMovement.SetInput(Vector2.zero);
                        inputLocked = false;
                        break;
                    }
                }
            }
        }
    }

    void OnMove(InputValue input)
    {
        var newInput = input.Get<Vector2>();
        if (newInput.x != 0 && newInput.y != 0)
        {
            newInput.x = Mathf.Sign(newInput.x);
            newInput.y = 0;
        }

        lastInput = newInput;
        inputLocked = false;
    }

    void OnViewShadowRealm(InputValue input)
    {
        worldStateManager.SwitchState();

        //StartCoroutine(LoopCheckCapRange());
        fxManager.ShadowSightON();
    }

    //void OnLookAround(InputValue input)
    //{
    //    if (input.isPressed)
    //    {
    //        cameraManager.lookAroundInputTriggered = true;
    //    }

    //    else
    //    {
    //        cameraManager.lookAroundInputTriggered = false;
    //    }
    //}

    void OnInteract(InputValue input)
    {
        if (input.isPressed)
        {
            if (playerInteractables.interactable != null)
            {
                playerInteractables.interactable.Interact();
            }
        }
    }

    //// Incase the shadow enters the light after initial check...
    //public IEnumerator LoopCheckCapRange()
    //{
    //    for (int i = 0; i < 1; i++)
    //    {
    //        foreach (ShadowStateManager shadow in shadows)
    //        {
    //            shadow.CheckWithinCapRange();
    //        }

    //        yield return new WaitForSecondsRealtime(0.25f);
    //    }
    //}
}
