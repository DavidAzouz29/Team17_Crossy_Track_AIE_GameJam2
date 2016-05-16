/// <summary>
/// Author: 		David Azouz
/// Date Created: 	11/04/16
/// Date Modified: 	11/04/16
/// --------------------------------------------------
/// Brief: A Menu Script class that interprets data to present on the U.I.
/// viewed https://www.youtube.com/watch?v=y3OZXMxsrUI
/// http://answers.unity3d.com/questions/1109497/unity-53-how-to-load-current-level.html
/// 
/// ***EDIT***
/// - Menu and related systems working 	- David Azouz 11/04/16
/// - Remaining comments added 		- David Azouz 11/04/16
/// - Credits added					- David Azouz 12/04/16
/// 
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    //----------------------------------
    // PUBLIC VARIABLES
    //----------------------------------
    public GameObject controlsPanel; //Store a reference to the Game Object ControlsPanel
    public GameObject creditsPanel; //Store a reference to the Game Object ControlsPanel

    //----------------------------------
    // PRIVATE VARIABLES
    //----------------------------------
    private bool isControls = false;
    private bool isCredits = false;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If 'C' is pressed...
        if(Input.GetKeyUp(KeyCode.C))
        {
            //... show/ hide the controls
            ToggleControlsView();
            //Debug.Log("isCon: " + isControls);
        }
	}

    #region Panels
    ///-----------------------------------
    /// <summary> 
    /// Shows/ hides the 'controls' panel
    /// </summary>
    ///-----------------------------------
    public void ToggleControlsView()
    {
        // toggle controls true/ false
        isControls = !isControls;
        // set the controls panel on/ off
        controlsPanel.SetActive(isControls);
    }

    ///-----------------------------------
    /// <summary> 
    /// Shows/ hides the 'credits' panel
    /// </summary>
    ///-----------------------------------
    public void ToggleCreditsView()
    {
        // toggle credits true/ false
        isCredits = !isCredits;
        // set the credits panel on/ off
        creditsPanel.SetActive(isCredits);
    }
    #endregion

    // Load the level to play the game
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    // If the player wants to play again, reload the currently loaded level.
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Quits the game
    public void Quit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif
        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
