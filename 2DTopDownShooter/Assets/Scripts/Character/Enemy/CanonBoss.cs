using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        LookAtTarget(target);
    }

    private void LookAtTarget(Transform target)
    {
        Vector3 toTargetVector = target.position - transform.position;
        float targetPosition = Mathf.Atan2(toTargetVector.y, toTargetVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetPosition + 270f));
    }
}
