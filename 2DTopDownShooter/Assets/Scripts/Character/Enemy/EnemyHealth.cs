using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 5;
    public HealthBar HealthBar;

    private void Start()
    {
        HealthBar.SetMaxHealth(Health);
    }

    private void OnDestroy()
    {
        GameController.Instance.Destroyed += 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            Health -= 1;

            HealthBar.SetHealth(Health);

            Debug.Log(Health);

            if (Health <= 0)
            {
                Destroy(this.gameObject);
            }            
        }
    }
}
