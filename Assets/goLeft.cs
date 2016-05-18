using UnityEngine;
using System.Collections;

public class goLeft : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		//checks if the train is supposed to change tracks
		if (other.GetComponent<train> ().change) 
		{
			other.transform.Rotate (0, Mathf.Lerp (0, 25, 3), 0);
		}
	}
}
