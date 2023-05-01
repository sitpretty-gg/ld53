using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonfly : MonoBehaviour
{

    // noise on the localTransform
    float minX = -0.25f;
    float maxX = 0.25f;
    float minY = -0.10f;
    float maxY = 0.10f;

    Vector3 currentOffsetV3;
    public Vector3 southV3 = new Vector3(0, -0.25f);
    public Vector3 northV3 = new Vector3(0, 0.25f);
    public Vector3 eastV3 = new Vector3(0.5f, 0);
    public Vector3 westV3 = new Vector3(-0.5f, 0);

    Vector3 targetPos;

    float speed = 1f;
    float interval;

    // Start is called before the first frame update
    void Start()
    {
        currentOffsetV3 = eastV3;
        interval = speed * Time.deltaTime;
        StartCoroutine(Float());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, interval);
    }

    private IEnumerator Float()
    {
        while (true)
        {
            Vector3 newPos = new Vector3();
            newPos.x = (currentOffsetV3.x + Random.Range(minX, maxX));
            newPos.y = (currentOffsetV3.y + Random.Range(minY, maxY));
            targetPos = newPos;

            yield return new WaitForSeconds(Random.Range(0.4f, 0.7f));
        }
    }

    public void SetLocalPosition(Vector3 newPosition)
    {
        currentOffsetV3 = newPosition;
        targetPos = newPosition;
    }
}
