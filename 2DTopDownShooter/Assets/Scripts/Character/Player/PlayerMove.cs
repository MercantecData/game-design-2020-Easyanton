﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMove : MonoBehaviour
{        
    private float Speed = 33f;
    private Rigidbody2D _rigidbody;

    // Animation.
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update.
    void Start()
    {        
        _rigidbody = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame.
    void Update()
    {        
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 GoTo = (transform.position + new Vector3(x * Speed, y * Speed) * Time.deltaTime);

        if (!(transform.position == GoTo))
        {
            _rigidbody.MovePosition(GoTo);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }       
    }
}
