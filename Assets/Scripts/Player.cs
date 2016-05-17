/// -------------------------------------------------
/// <summary>
/// Author: 		David Azouz
/// Date Created: 	16/05/16
/// Date Modified: 	16/05/16
/// --------------------------------------------------
/// Brief: A Player class that handles movement and player state (alive).
/// viewed http://docs.unity3d.com/ScriptReference/Handheld.Vibrate.html
/// 
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
    public bool isTrainComing = false;
    public int iMovement = 10;
    public int iTimeBeforeGameOver = 2;
    public GameObject c_GameOverPanel;
    public Animator c_GameOverText;
    public Animator c_CharacterMovement;

    // Use this for initialization
    /*void Start ()
    {
        //c_GameOverPanel.GetComponent<>
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    } */

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 10, 1000, 320), "Vibrate!"))
        {
            Handheld.Vibrate();
            
        }
    }
    void OnCollisionEnter(Collider other)
    {
        if (other.transform.tag == "Train")
        {
            Invoke("GameOver", iTimeBeforeGameOver);
            c_CharacterMovement.CrossFade("Death", 1);
        }
    }

    void GameOver()
    {
        c_GameOverPanel.SetActive(true);
        c_GameOverText.Play("GameOverText");
    }
}
