using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        // Changes scene to the play scene
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
