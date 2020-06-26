using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{    
    private float BulletSpeed = 68f;
    public GameObject BulletPrefab;
    public Transform MuzzleFlashPrefab;

    // Update is called once per frame.
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Sound.
        Audio.Instance.SingleShoot();

        // Bullet.
        GameObject bulletClone = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = bulletClone.GetComponent<Rigidbody2D>();
        rigidbody.velocity = bulletClone.transform.up * BulletSpeed;
        Destroy(bulletClone, 3f);

        // Muzzle flash.       
        Vector3 muzzlePosition = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.6f, transform.position.z);
        Transform muzzleClone = (Transform)Instantiate(MuzzleFlashPrefab, muzzlePosition, transform.rotation);
        float size = Random.Range(0.3f, 0.6f);
        muzzleClone.localScale = new Vector3(size, size, size);

        // Bullet count.
        GameController.Instance.BulletCount += 1;

        // Destroy.
        Destroy(muzzleClone.gameObject, 0.1f);
    }
}


