using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void Button22Pressed()
    {
        BoardParamsScript.Height = 2;
        BoardParamsScript.Width = 2;
        SceneManager.LoadScene("GameScene");
        
    }
    public void Button42Pressed()
    {
        BoardParamsScript.Height = 2;
        BoardParamsScript.Width = 4;
        SceneManager.LoadScene("GameScene");

    }
    public void Button44Pressed()
    {
        BoardParamsScript.Height = 4;
        BoardParamsScript.Width = 4;
        SceneManager.LoadScene("GameScene");

    }
}
