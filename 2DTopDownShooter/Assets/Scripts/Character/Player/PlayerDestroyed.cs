using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyed : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        GameController.Instance.PlayerDestroyed = true;

        animator.SetBool("Explode", true);
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag != "Wall")
    //    {
    //        Destroy(other.gameObject);
    //        //Destroy(this.gameObject); // For debug
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}