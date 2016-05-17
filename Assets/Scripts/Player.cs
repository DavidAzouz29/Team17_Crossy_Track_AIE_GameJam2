/// -------------------------------------------------
/// <summary>
/// Author: 		David Azouz
/// Date Created: 	16/05/16
/// Date Modified: 	16/05/16
/// --------------------------------------------------
/// Brief: A Player class that handles movement and player state (alive).
/// viewed http://docs.unity3d.com/ScriptReference/Handheld.Vibrate.html
/// Audio death http://soundbible.com/1953-Neck-Snap.html
/// 
/// ***EDIT***
/// - Menu and related systems working 	- David Azouz 16/05/16
/// 
/// </summary>
/// -------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    //public bool isTrainComing = false;
    //public int iMovement = 10;
    public float fTimeBeforeGameOver = 0.90f;
    public GameObject c_GameOverPanel;
    public Animator c_GameOverText;
    public Animator c_CharacterMovement;
    public Button c_PauseButton;
    public AudioSource c_DeathSound;

    void OnGUI()
    {
        // Test vibration
//        if (GUI.Button(new Rect(0, 50, 1000, 320), "Vibrate!"))
//        {
//            Handheld.Vibrate();
//        }
        //TODO: remove once testing is complete
        /*if (GUI.Button(new Rect(0, Screen.height - 50, 100, 32), "Die"))
        {
            Death();
        } */
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Train")
        {
            Death();
        }
    }

    void GameOver()
    {
        c_GameOverPanel.SetActive(true);
        c_GameOverText.Play("GameOverText");
        c_PauseButton.interactable = false;
    }

    // What happens when the player dies/ gets hit by a train
    public void Death()
    {
        Invoke("GameOver", fTimeBeforeGameOver);
        c_CharacterMovement.CrossFade("Death", 1);
        c_DeathSound.Play();
#if UNITY_ANDROID
            Handheld.Vibrate();
#endif
    }
}
