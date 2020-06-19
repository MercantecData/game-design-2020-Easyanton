﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Wall")
        {            
            Destroy(other.gameObject);
            Destroy(this.gameObject); // For debug
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}