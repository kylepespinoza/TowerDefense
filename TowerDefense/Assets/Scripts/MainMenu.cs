using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public bool isStart;
    public bool isQuit;

    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(1);
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
}
