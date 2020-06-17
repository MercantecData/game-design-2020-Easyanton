using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {       
            GameObject newBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rigidbody = newBullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = newBullet.transform.up * 23;
            
            Destroy(newBullet, 10);
        }
    }
}


