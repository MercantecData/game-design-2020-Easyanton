using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Game controller
    public static GameController Instance;

    // Player
    public int BulletCount = 0;
    public int Destroyed = 0;
    public bool PlayerDestroyed = false;

    // Enemy
    [SerializeField]
    private GameObject BossDoor;

    // UI
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private Text BulletUI;
    [SerializeField]
    private Text YouWin;
    [SerializeField]
    private Text YouLose;
    [SerializeField]
    private GameObject BossModal;

    void Awake()
    {
        Instance = this;

        UI.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("WinOrLoseCheck", 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // UI        
        BulletUI.text = $"Bullet count: {BulletCount} \r\nEnemy destroyed: {Destroyed}";          
    }

    private void WinOrLoseCheck()
    {
        if (Destroyed == 3)
        {
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
}
