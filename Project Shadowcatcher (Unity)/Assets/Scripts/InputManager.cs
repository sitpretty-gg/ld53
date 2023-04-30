using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    WorldStateManager worldStateManager;
    [SerializeField] ShadowStateManager [] shadows;
    PlayerMovement playerMovement;
    CanvasManager canvasManager;
    private FXManager fxManager;
    

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        canvasManager = FindObjectOfType<CanvasManager>();
        worldStateManager = FindObjectOfType<WorldStateManager>();
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
