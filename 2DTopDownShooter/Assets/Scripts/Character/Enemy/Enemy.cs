using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy peed and range.    
    private float speed = 10f;    
    private float rangeMove = 27f;    
    private float rangeAttack = 16f;

    private string Currentstate = "Patrol";

    // Waypoints.
    private Transform nextWaypoint;
    [SerializeField]
    private Transform waypoint1;
    [SerializeField]
    public Transform waypoint2;

    public LayerMask mask;

    // Start is called before the first frame update.
    void Start()
    {
        nextWaypoint = waypoint1;
    }


    // Update is called once per frame.
    void Update()
    {
        if (Currentstate == "Patrol")
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime * speed);
            transform.position = nextPosition;

            LookAtTarget(nextWaypoint);

            if (transform.position == nextWaypoint.position)
            {
                if (nextWaypoint == waypoint1)
                {
                    nextWaypoint = waypoint2;
                }
                else
                {
                    nextWaypoint = waypoint1;
                }
            }

            if (TargetAqurired(rangeMove))
            {
                Currentstate = "Attack";
            }

        }
        else if (Currentstate == "Attack")
        {
            if (!TargetAqurired(rangeMove))
            {
                Currentstate = "Patrol";
            }
            else
            {
                Transform target = GameObject.FindGameObjectWithTag("Player").transform;

                // Look at taget.
                LookAtTarget(target);

                // Shoot target.
                if (!TargetAqurired(rangeAttack))
                {
                    // Move to target.
                    Vector2 nextPosition = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
                    transform.position = nextPosition;
                }                
            }
        }

    }

    private void LookAtTarget(Transform target)
    {
        Vector3 toTargetVector = target.position - transform.position;
        float targetPosition = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetPosition + 270f));
    }

    private bool TargetAqurired(float range)
    {
        GameObject targetobjcet = GameObject.FindGameObjectWithTag("Player");

        bool inrange = false;
        if (Vector2.Distance(targetobjcet.transform.position, transform.position) < range)
        {
            inrange = true;
        }

        var linecast = Physics2D.Linecast(transform.position, targetobjcet.transform.position, mask);

        bool inVision = false;
        if (linecast == false)
        {
            inVision = true;
        }        

        return inrange && inVision;
    }
}


