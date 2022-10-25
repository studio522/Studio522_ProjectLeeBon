using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeGuideSetController : MonoBehaviour
{
    Transform StartPoint, StopPoint;
    public GameObject Spore, Guide;
    float guideSpeed = 0.001f;
    float sporeSpeed = 0.0001f;

    void Start()
    {
        StartPoint = GameObject.Find("StartPoint").transform;
        StopPoint = GameObject.Find("StopPoint").transform;
        Guide.transform.position = StartPoint.position;
        Spore.transform.position = StartPoint.position;
        guideSpeed = Random.Range(0.01f, 0.005f);
        sporeSpeed = Random.Range(0.01f, 0.005f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Guide.transform.position = StartPoint.position;
            Spore.transform.position = StartPoint.position;
        }
        GuideToStopPoint();
        FollowGuide();
    }
    void GuideToStopPoint()
    {
        Guide.transform.position = Vector3.Lerp(Guide.transform.position, StopPoint.position, guideSpeed);
        
        float dist = Vector3.Distance(Guide.transform.position, StopPoint.position);
        //if (dist < 0.2)
        //{
        //    Guide.transform.position = StartPoint.position;
        //}

        float randomNum = Random.value;
        if (randomNum < 0.01f)
        {
            //print(randomNum);
            float randomRange = dist * 0.3f;
            //print(randomRange);
            Guide.transform.position += Vector3.one * Random.Range(-randomRange, randomRange);
            //print(Random.Range(-randomRange, randomRange));
        }
    }

    void FollowGuide()
    {
        Vector3 TargetPosition = Vector3.zero;
        float distToStopPoint = Vector3.Distance(Spore.transform.position, StopPoint.position);
        if (distToStopPoint > 1)
        {
            TargetPosition = Guide.transform.position;
        }
        else
        {
            //Spore.transform.position = Guide.transform.position;
            //TargetPosition = StopPoint.position;

            float radius = 1f;
            float angle = Random.Range(0, 360);
            float x = radius * Mathf.Cos(angle) + StopPoint.position.x;
            float y = radius * Mathf.Sin(angle) + StopPoint.position.y;
            float z = StopPoint.position.z;

            sporeSpeed = 0;
            Vector3 newPos = new Vector3(x, y, z);
            Spore.transform.position = newPos;
            print("stopped");
            //Destroy(gameObject, 2);
        }

        Spore.transform.position = Vector3.Lerp(Spore.transform.position, TargetPosition, sporeSpeed);

    }
}

