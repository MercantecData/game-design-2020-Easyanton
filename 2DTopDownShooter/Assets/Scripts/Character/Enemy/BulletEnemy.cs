using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{    
    private float BulletSpeed = 40f;
    public GameObject BulletPrefab;
    public Transform MuzzleFlashPrefab;
    
    private float RangeAttack = 20f;

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {      
        InvokeRepeating("Fire", 0.1f, 0.7f);
    }

    private void Update()
    {
    }

    // Update is called once per frame
    private void Fire()
    {
        if (!TargetAqurired(RangeAttack))
        {
            return;
        }

        // Bullet
        GameObject bulletClone = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = bulletClone.GetComponent<Rigidbody2D>();
        rigidbody.velocity = bulletClone.transform.up * BulletSpeed;
        Destroy(bulletClone, 3f);

        // Bullet count
        GameController.Instance.BulletCount += 1;

        // Muzzle flash        
        Vector3 muzzlePosition = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.6f, transform.position.z);
        Transform muzzleClone = (Transform)Instantiate(MuzzleFlashPrefab, muzzlePosition, transform.rotation);
        float size = Random.Range(0.3f, 0.6f);
        muzzleClone.localScale = new Vector3(size, size, size);

        Destroy(muzzleClone.gameObject, 0.1f);
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
