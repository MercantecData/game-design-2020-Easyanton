using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneData : MonoBehaviour
{
    public int BulletCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {        
        DontDestroyOnLoad(gameObject);
        BulletCount = GameController.Instance.BulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
