using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] Slider batterySliderUI;

    int capturedGhosts = 0;
    [SerializeField] TextMeshProUGUI capturedGhostsUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateCapturedGhosts(int increase)
    {
        capturedGhosts += increase;
        capturedGhostsUI.text = capturedGhosts.ToString("000");
    }
}
