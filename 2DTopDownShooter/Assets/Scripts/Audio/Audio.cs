using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Instance.
    public static Audio Instance;

    // Music.
    [SerializeField]
    private AudioClip MissionMusic;
    [SerializeField]
    private AudioClip BossMusic;
    [SerializeField]
    private AudioClip SingleShotEffect;
    [SerializeField]
    private AudioClip CanonShotEffect;


    // Players.
    private AudioSource MusicSource;
    private AudioSource ShotSource;
    private AudioSource CanonSource;

    // Active.
    private bool BossActive = false;

    // Start is called before the first frame update.
    void Start()
    {
        // Instance
        Instance = this;

        // Mission music.        
        MusicSource = gameObject.AddComponent<AudioSource>();
        MusicSource.clip = MissionMusic;        
        MusicSource.loop = true;
        MusicSource.Play();

        // Single shot music.
        ShotSource = gameObject.AddComponent<AudioSource>();
        ShotSource.clip = SingleShotEffect;
        ShotSource.playOnAwake = false;
        ShotSource.loop = false;

        // Canon shot.
        CanonSource = gameObject.AddComponent<AudioSource>();
        CanonSource.clip = CanonShotEffect;
        CanonSource.playOnAwake = false;
        CanonSource.loop = false;
    }

    public void PlayBossSong()
    {
        if (BossActive != true)
        {
            BossActive = true;
            MusicSource.Stop();
            MusicSource.clip = BossMusic;
            MusicSource.Play();
        }
    }

    public void SingleShoot()
    {
        ShotSource.Play();
    }

    public void CanonShoot()
    {
        CanonSource.Play();
    }
}
