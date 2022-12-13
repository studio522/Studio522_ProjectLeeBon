using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    Transform StartPos;
    Transform GuidePos;
    Transform DandelionHead;
    float speed = 0.005f;
    bool hasReached = false;

    void Start()
    {
        StartPos = GameObject.Find("StartPoint").transform;
        transform.position = StartPos.position;

        GuidePos = transform.parent.Find("LetterGuide");
        DandelionHead = transform.parent.parent.parent.Find("Dandelion/Head");
    }

    // Update is called once per frame
    void Update()
    {
        FollowGuide();
    }
    void FollowGuide()
    {
        Vector3 TargetPosition = GuidePos.transform.position;
        float distToStopPoint = Vector3.Distance(transform.position, DandelionHead.position);
        //print("distToStopPoint:" + distToStopPoint);

        float radius = 1f;
        if (distToStopPoint > radius * 1.5)
        {
            //print("following");
            transform.position = Vector3.Lerp(transform.position, TargetPosition, speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, DandelionHead.position, speed*0.1f);
            if (!hasReached)
            {                
                float angle = Random.Range(0, 360);
                float x = radius * Mathf.Cos(angle) + DandelionHead.position.x;
                float y = radius * Mathf.Sin(angle) + DandelionHead.position.y;
                float z = DandelionHead.position.z;
                speed = 0;
                Vector3 newPos = new Vector3(x, y, z);
                transform.position = newPos;
                print("stopped");
                hasReached = true;
                transform.SetParent(DandelionHead);
                print(transform.parent.name);
            }


            //Destroy(gameObject, 2);
        }
    }
}
