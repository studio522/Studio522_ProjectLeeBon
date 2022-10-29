using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGuideController : MonoBehaviour
{
    //Transform StartPointReference; // StartPoint
    //Transform TargetPointReference; // StartPoint

    Transform GuideStart; // Dandelion > Head
    Transform GuideTarget; // Dandelion > Head
    float speed;
    float speedMin = 0.001f;
    float speedMax; // Letter Guide Speed;
    public int value = 10;
    void Start()
    {
        // Set Starting Pos
        GuideStart = GameObject.Find("StartPoint").transform;
        transform.position = GuideStart.position;

        speedMax = speedMin * 5;
        speed = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        GuideToStopPoint();
    }

    void GuideToStopPoint()
    {
        // Set Target Pos
        Transform Dandelion = transform.parent.parent.parent.Find("Dandelion");
        //print(Dandelion.name);
        GuideTarget = Dandelion.Find("Head");
        //print(GuideTarget.name);

        transform.position = Vector3.Lerp(transform.position, GuideTarget.position, speed);

        float dist = Vector3.Distance(transform.position, GuideTarget.position);
        float randomNum = Random.value;
        if (randomNum < 0.01f)
        {
            //print(randomNum);
            float randomRange = dist * 0.3f;
            //print(randomRange);
            transform.position += Vector3.one * Random.Range(-randomRange, randomRange);
            //print(Random.Range(-randomRange, randomRange));
        }
    }
}
