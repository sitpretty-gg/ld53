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
    

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerInteractables = FindObjectOfType<PlayerInteractables>();
        canvasManager = FindObjectOfType<CanvasManager>();
        worldStateManager = FindObjectOfType<WorldStateManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        fxManager = FindObjectOfType<FXManager>();
    }

    void OnMove(InputValue input)
    {
        playerMovement.SetInput(input.Get<Vector2>());
    }

    void OnViewShadowRealm(InputValue input)
    {
        worldStateManager.SwitchState(worldStateManager.shadowWorldState);
        StartCoroutine(LoopCheckCapRange());
        fxManager.ShadowSightON();
    }

    void OnLookAround(InputValue input)
    {
        if (input.isPressed)
        {
            cameraManager.lookAroundInputTriggered = true;
            Debug.Log("lookAround called");
        }

        else
        {
            cameraManager.lookAroundInputTriggered = false;
            Debug.Log("lookAround turned off");
        }
    }

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

    // Incase the shadow enters the light after initial check...
    IEnumerator LoopCheckCapRange()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (ShadowStateManager shadow in shadows)
            {
                shadow.CheckWithinCapRange();
            }

            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
}
