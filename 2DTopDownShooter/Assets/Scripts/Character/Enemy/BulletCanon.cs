using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCanon : MonoBehaviour
{
    private float BulletSpeed = 60f;
    public GameObject BulletPrefab;
    public Transform MuzzleFlashPrefab;

    private float RangeAttack = 50f;

    public LayerMask mask;

    // Shake.
    [SerializeField]
    private GameObject ShakerCameraObject;
    private ShakeBehavior Shaker;

    private void Awake()
    {
        Shaker = ShakerCameraObject.GetComponent(typeof(ShakeBehavior)) as ShakeBehavior;
    }

    // Start is called before the first frame update.
    void Start()
    {
        InvokeRepeating("Fire", 0.1f, 0.8f);
    }

    // Update is called once per frame.
    private void Fire()
    {
        if (!TargetAqurired(RangeAttack))
        {
            return;
        }

        // Canon sound effect.
        Audio.Instance.CanonShoot();

        // Bullet.
        GameObject bulletClone = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = bulletClone.GetComponent<Rigidbody2D>();
        rigidbody.velocity = bulletClone.transform.up * BulletSpeed;
        Destroy(bulletClone, 3f);

        // Shake screen.
        Shaker.TriggerShake();

        // Muzzle flash.       
        Vector3 muzzlePosition = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.6f, transform.position.z);
        Transform muzzleClone = (Transform)Instantiate(MuzzleFlashPrefab, muzzlePosition, transform.rotation);
        float size = Random.Range(0.8f, 0.20f);
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
