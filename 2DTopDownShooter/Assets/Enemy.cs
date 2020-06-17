using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public float range = 15;

    private string currentState = "Patrol";
    
    private Transform nextWaypoint;
    public Transform waypoint1;
    public Transform waypoint2;

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentState == "Patrol")
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime * speed);
            transform.position = nextPosition;


            Debug.Log(transform.position);
            Debug.Log(nextWaypoint.position);
            if (transform.position == nextWaypoint.position)
            {
                Debug.Log("Got here to");
                if (nextWaypoint == waypoint1)
                {
                    nextWaypoint = waypoint2;
                }
                else
                {
                    nextWaypoint = waypoint1;
                }
            }
        }
        else if (currentState == "Attack")
        {



        }
    }

    bool TargetAqurired()
    {
        GameObject targetobjcet = GameObject.FindGameObjectWithTag("Player");
        bool inrange = false;
//        if(Vector2.Distance(targetobjcet.transform.position, transform.position < range))
//{
//            inrange = true;
//        }

        var linecast = Physics2D.Linecast(transform.position, targetobjcet.transform.position, mask);

        bool inVision = false;
        if (linecast == null)
        {
            inVision = true;
        }
        return inrange && inVision;
        }


}


