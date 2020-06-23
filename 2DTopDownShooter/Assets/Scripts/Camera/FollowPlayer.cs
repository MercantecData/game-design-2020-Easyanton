using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        var playerPosition = player.position;
        playerPosition.z = transform.position.z;

        var target = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, 0.3f);
        transform.position = target;

    }
}
