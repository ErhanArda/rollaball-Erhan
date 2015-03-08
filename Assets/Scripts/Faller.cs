using UnityEngine;
using System.Collections;

public class Faller : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
		gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);

			
		}
		
		
	}*/
}
