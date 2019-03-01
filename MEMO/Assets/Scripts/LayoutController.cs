using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LayoutController : MonoBehaviour {

    public void RestartButtonOnClick()
    {
        SceneManager.LoadScene("MainMenuScene");

    }
}
