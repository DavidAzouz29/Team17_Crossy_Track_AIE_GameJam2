using UnityEngine;
using System.Collections;

public class goStright : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
		void OnTriggerEnter(Collider other)
		{
		other.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(transform.rotation.y,0,3), 0);
		} 
}
