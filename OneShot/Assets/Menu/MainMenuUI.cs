using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void TutorialGameButton()
    {
        SceneManager.LoadScene(2);
    }

}
