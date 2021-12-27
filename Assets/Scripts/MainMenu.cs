using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject menu, loadingInterface;
    public Image loadingProgressBar;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public void StartGame()
    {
        HideMenu();
        ShowLoadingScreen();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Home", LoadSceneMode.Single));
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("House1", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
        //DeleteAudioListeners();
    }

    public void LoadSceneNamed(string scene)
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync($"{scene}", LoadSceneMode.Additive));
    }

    public void LoadSceneTest()
    {
        LoadSceneNamed("House1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }

    public void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
    }

    public void DeleteAudioListeners()
    {
        AudioListener[] aL = FindObjectsOfType<AudioListener>();
        for (int i = 0; i < aL.Length; i++)
        {
            //Destroy if AudioListener is not on the MainCamera
            if (aL[i] != aL[0])
            {
                DestroyImmediate(aL[i]);
            }
        }
    }    
    

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for(int i=0; i<scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
    }


}
