using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Game controller
    public static GameController Instance;

    // Player data save.
    [SerializeField]
    private Transform playerDataPrefab;

    // Player.
    public int BulletCount = 0;
    public int Destroyed = 0;
    public bool PlayerDestroyed = false;

    // Enemy.
    [SerializeField]
    private GameObject BossDoor;

    // UI.
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private TextMeshProUGUI BulletUI;
    [SerializeField]
    private GameObject YouWin;
    [SerializeField]
    private GameObject YouLose;
    [SerializeField]
    private GameObject BossModal;

    // Animations.
    private Animator Anim;

    void Awake()
    {
        Instance = this;

        UI.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load data from last scene.
        var sevedData = GameObject.FindGameObjectWithTag("NextScene");

        if (sevedData != null)
        {
            BulletCount = sevedData.GetComponent<NextSceneData>().BulletCount;
        }

        // Win or lose check.
        InvokeRepeating("WinOrLoseCheck", 1f, 0.5f);
    }

    // Update is called once per frame.
    void Update()
    {
        // UI.        
        BulletUI.text = $"Bullet count: {BulletCount} \r\nEnemy destroyed: {Destroyed}";          
    }

    private void WinOrLoseCheck()
    {
        if (Destroyed == 3)
        {
            Audio.Instance.PlayBossSong();
            BossModal.SetActive(true);
            BossDoor.SetActive(false);

        }
        if (Destroyed == 4)
        {
            YouWin.gameObject.SetActive(true);
        }
        if (PlayerDestroyed == true)
        {
            YouLose.gameObject.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        // Restart game scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextMission()
    {
        // Move bullet count to next scene.                
        Instantiate(playerDataPrefab, new Vector3(), transform.rotation);

        // Load next scene with animation.
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

    }

    private IEnumerator LoadScene(int levelIndex)
    {
        LevelLoader.instance.FadeEffekt();

        yield return new WaitForSeconds(1f);

        // Next game scene.
        SceneManager.LoadScene(levelIndex);
    }
}
