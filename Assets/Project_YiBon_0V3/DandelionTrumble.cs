using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionTrumble : MonoBehaviour
{
    float timePassed;
    Vector3 OriginalPos;
    Vector3 OriginalScale;
    public int LettersCount;
    float randomScale = 0.3f;

    void Start()
    {
        OriginalPos = transform.position;
        OriginalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTrumble();
        }
        Trumble();
    }

    public void StartTrumble()
    {
        if (transform.childCount == LettersCount)
        {
            timePassed = 0;
            randomScale = Random.Range(0f, 1f);
        }
    }

    void Trumble()
    {
        timePassed += Time.deltaTime;
        if (timePassed < 0.5f)
        {
            //transform.position = OriginalPos + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            float randomS = Random.Range(-randomScale, randomScale);
            transform.localScale = OriginalScale + new Vector3(randomS, randomS, randomS);
        }
        else
        {
            //transform.position = OriginalPos;
            transform.localScale = OriginalScale;
        }
    }
}
