﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        var mouseposition = Input.mousePosition;
        var worldPosition = Camera.main.ScreenToWorldPoint(mouseposition);

        var cowToMousePostion = worldPosition - transform.position;
        cowToMousePostion.z = 0;
        transform.up = cowToMousePostion;
    }
}
