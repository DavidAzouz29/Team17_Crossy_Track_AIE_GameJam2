using UnityEngine;
using System.Collections;

public class goEither : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//checks if the train is supposed to change tracks
		if (other.GetComponent<train> ().change) 
		{
			Random.seed += (int)Time.deltaTime;
			int toChange = Random.Range (0, 2);
			//decides which way to go
			if (toChange == 0) {
				
				other.transform.Rotate (0, Mathf.Lerp (0, -25, 3), 0);
			} else {
				Debug.Log (toChange);
				other.transform.Rotate (0, Mathf.Lerp (0, 25, 3), 0);

			}
		}
	}
}
