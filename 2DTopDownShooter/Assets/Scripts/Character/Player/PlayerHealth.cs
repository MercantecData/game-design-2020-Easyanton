using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;

    public int Health = 5;
    public HealthBar HealthBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        HealthBar.SetMaxHealth(Health);
    }

    private void OnDestroy()
    {
        GameController.Instance.PlayerDestroyed = true;

        animator.SetBool("Explode", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            Health -= 1;

            HealthBar.SetHealth(Health);

            if (Health <= 0)
            {
                animator.SetBool("Explode", true);
                Destroy(this.gameObject, 1f);
            }
        }
    }
}