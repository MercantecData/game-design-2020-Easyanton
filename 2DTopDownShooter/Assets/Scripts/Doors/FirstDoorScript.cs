using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoorScript : MonoBehaviour
{
    // Animation.
    private Animator animator;

    // Range.
    private float range = 17f;
    public LayerMask mask;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame.
    void Update()
    {        
        if (TargetAqurired(range))
        {            
            animator.SetBool("Open", true);
        }
        else
        {
            animator.SetBool("Open", false);
        }
    }

    private bool TargetAqurired(float range)
    {
        GameObject targetobjcet = GameObject.FindGameObjectWithTag("Player");

        bool inRange = false;
        if (Vector2.Distance(targetobjcet.transform.position, transform.position) < range)
        {
            inRange = true;
        }

        var linecast = Physics2D.Linecast(transform.position, targetobjcet.transform.position, mask);

        bool inVision = false;
        if (linecast == false)
        {
            inVision = true;
        }

        return inRange && inVision;
    }
}
