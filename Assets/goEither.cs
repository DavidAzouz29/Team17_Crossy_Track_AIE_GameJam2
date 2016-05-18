using UnityEngine;
using System.Collections;

public class goEither : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}
	void OnTriggerEnter(Collider other)
	{
		//checks if the train is supposed to change tracks
		if (other.GetComponent<train> ().change) 
		{
			Random.seed += (int)Time.deltaTime;
			int toChange = Random.Range (0, 2);
			Debug.Log (toChange);
			if (toChange == 0) {
				
				other.transform.Rotate (0, Mathf.Lerp (0, -25, 3), 0);
			} else {
				Debug.Log (toChange);
				other.transform.Rotate (0, Mathf.Lerp (0, 25, 3), 0);

			}
		}
	}
}
