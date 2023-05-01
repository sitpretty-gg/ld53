using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] List<GameObject> collectionIndicators;
    [SerializeField] Transform batteryTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBattey(float newUse)
    {
        // full battery = 0.4
        // set the transform.scale.y of the battery to the new batteryamount
    }

    public void UpdateCollectedShadows(int collected)
    {
        if (collected != 0)
        {
            for (int i = 0; i < collected; i++)
            {
                collectionIndicators[i].SetActive(true);
            }
        }
    }


    public void SetElementVisiblity(bool setter)
    {
        batteryTransform.GetComponent<SpriteRenderer>().enabled = setter;
    }
}
