using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform Cam;
    void LateUpdate()
    {
        transform.LookAt(transform.position + Cam.forward);

        //var wantedPos = Camera.main.WorldToScreenPoint(transform.position);
        //transform.position = wantedPos;
    }
}
