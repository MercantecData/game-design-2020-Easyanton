using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyed : MonoBehaviour
{
    private void OnDestroy()
    {
        GameController.Instance.Destroyed += 1;
    }
}
