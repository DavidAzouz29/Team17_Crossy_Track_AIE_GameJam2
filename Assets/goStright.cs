using UnityEngine;
using System.Collections;

public class goStright : MonoBehaviour {


	// Update is called once per frame
	void Update () {

	}
		void OnTriggerEnter(Collider other)
		{
		//changes the trains to continue going down the track
		other.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(transform.rotation.y,0,3), 0);
		} 
}
