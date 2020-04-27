using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasswordScreen : MonoBehaviour
{
    public void SubmitButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
