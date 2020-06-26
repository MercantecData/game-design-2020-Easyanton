using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator Anim;

    public void PlayGame()
    {
        // Load game scene.        
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadScene(int levelIndex)
    {
        LevelLoader.instance.FadeEffekt();

        yield return new WaitForSeconds(1f);

        // Next game scene.
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
