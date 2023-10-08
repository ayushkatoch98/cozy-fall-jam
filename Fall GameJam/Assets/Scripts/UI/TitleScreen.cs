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


        titleScreen.SetActive(false);
        levelScreen.SetActive(true);
        

    }

    public void openTitleScreen()
    {


        levelScreen.SetActive(false);
        titleScreen.SetActive(true);


    }


    public void loadLevel(int levelBuildIndex)
    {

        SceneManager.LoadScene(levelBuildIndex);

    }


}
