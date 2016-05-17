///<summary>
///----------------------------------------------------------------
///Author: Dylan Stephens
///Date Created: 16/5/16
///Date Modified:
///----------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {
    public int[] tracks;
    public int currentLevel;

    // Use this for initialization
    void Start () {
        // 
        currentLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //adds one to the level
        currentLevel += 1;
	}
}
