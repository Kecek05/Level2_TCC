using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtons : MonoBehaviour
{

    private TextMeshProUGUI gravityTxt;
    private Rigidbody2D rigidbody;

    public void PlayAgainBtn()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }


    private void Update()
    {
        gravityTxt.text = rigidbody.
    }
}
