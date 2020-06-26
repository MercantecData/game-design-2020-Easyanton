using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
 
    [SerializeField]
    private Animator Anim;

    private void Awake()
    {
        instance = this;        
    }

    public void FadeEffekt()
    {
        // Start animation.
        Anim.SetTrigger("SceneFade");
    }
}
