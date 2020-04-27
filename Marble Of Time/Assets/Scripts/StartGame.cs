using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level1-1");
    }
    public void PasswordButton()
    {
        SceneManager.LoadScene("Password");
    }
    public void CloseButton()
    {
        Application.Quit();
    }
}
