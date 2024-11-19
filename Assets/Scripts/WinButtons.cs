using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtons : MonoBehaviour
{

    public void PlayAgainBtn()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
