using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractables : MonoBehaviour
{

    public NPCInteract interactable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            interactable = collision.gameObject.GetComponent<NPCInteract>();
            interactable.SetPreview(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            interactable.SetPreview(false);
            interactable = null;
        }
    }

}
