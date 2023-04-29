using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{

    public Slider slider;
    TextMeshProUGUI tmPro;
    int uiInt = 0;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        tmPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSlider(float setter)
    {
        slider.value = setter;
    }

    public void UpdateTMPro()
    {
        uiInt += 1;
        tmPro.text = uiInt.ToString("000000");
    }
}
