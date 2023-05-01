using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] public string shadowLessText;
    [SerializeField] public string shadowText;


    [SerializeField] TextMeshPro tMpro;
    [SerializeField] SpriteRenderer bubbleSpriteRenderer;

    [SerializeField] Sprite smallBubble;
    [SerializeField] Sprite largeBubble;

    public void SetPreview(bool setter)
    {
        bubbleSpriteRenderer.sprite = smallBubble;
        bubbleSpriteRenderer.enabled = setter;

        if (setter == false)
        {
            tMpro.enabled = false;
        }
    }

    public void Interact()
    {
        bubbleSpriteRenderer.sprite = largeBubble;
        tMpro.enabled = true;
        bubbleSpriteRenderer.enabled = true;
    }

    public void SetText(string text)
    {
        tMpro.text = text;
    }
}
