/// <summary>
/// viewed: http://answers.unity3d.com/questions/25535/android-back-button-event.html
/// http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnApplicationPause.html
/// </summary>

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pause : MonoBehaviour
{
    public GameObject c_PausePanel;
    public bool paused;

    // Update is called once per frame
    private void Update()
    {
        // back button on android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    //if (Input.GetKeyDown(KeyCode.Menu))
    void OnApplicationPause(bool pauseStatus)
    {
        paused = pauseStatus;
        if(paused)
        {
            PauseGame();
        }
        else
        {
            UnPause();
            //TODO: SceneManager.LoadScene(Application.loadedLevel);
        }
    }

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
