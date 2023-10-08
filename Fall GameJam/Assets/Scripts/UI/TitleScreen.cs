using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject levelScreen;

    public void startNewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void openLevelsUI()
    {
        Debug.Log("opened levels screen");
        levelScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void openTitleScreen()
    {
        Debug.Log("opened title screen");
        titleScreen.SetActive(true);
        levelScreen.SetActive(false);
    }


    public void loadLevel(int levelBuildIndex)
    {
        SceneManager.LoadScene(levelBuildIndex);
    }
}
