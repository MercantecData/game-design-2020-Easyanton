using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Update is called once per frame.
    void LateUpdate()
    {
        var mouseposition = Input.mousePosition;
        var worldPosition = Camera.main.ScreenToWorldPoint(mouseposition);

        var playerToMousePostion = worldPosition - transform.position;
        playerToMousePostion.z = 0;
        transform.up = playerToMousePostion;
    }
}
