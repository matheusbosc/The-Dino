using System;
using System.Collections;
using _gAME.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public GameObject loadingScreen, mainMenu;

    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("LoadingScreen").Length > 1)
        {
            Destroy(loadingScreen);
            loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen");
        }
    }

    void Update()
    {
        
    }

    public void LoadGame(string a)
    {
        StartCoroutine("LoadLevelI", a);
    }

    IEnumerator LoadLevelI(string a)
    {
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(a);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
