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
using System.Collections;

public class Player : MonoBehaviour
{
    public bool isTrainComing = false;
    public int iMovement = 10;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //TODO: cleanup
//#if UNITY_ANDROID
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.transform.Translate(iMovement, 0, 0);
            gameObject.transform.Rotate(Mathf.Lerp(0, 20, Time.deltaTime), 0, 0);
        }
//#endif
        if (isTrainComing)
        {
            Handheld.Vibrate();
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 10, 1000, 320), "Vibrate!"))
        {
            Handheld.Vibrate();
            
        }
    }
}
