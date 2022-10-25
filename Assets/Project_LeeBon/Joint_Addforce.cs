using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_Addforce : MonoBehaviour
{
    public float power = 1;
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }
}
