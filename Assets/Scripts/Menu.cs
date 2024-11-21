using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
