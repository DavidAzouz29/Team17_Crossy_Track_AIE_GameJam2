using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    public Text r_text;
	[System.NonSerialized]
    public float fTimePassed;
	
	// Update is called once per frame
	void Update ()
    {
        fTimePassed += Time.deltaTime;
        //Set the text to the time to replicate a score.
        r_text.text = "Score: " + fTimePassed.ToString("f0");
    }
}
