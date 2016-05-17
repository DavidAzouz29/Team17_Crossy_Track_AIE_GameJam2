using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pause : MonoBehaviour
{
    public GameObject c_PausePanel;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        c_PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
