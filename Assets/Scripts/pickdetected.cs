using UnityEngine;
using System.Collections;

public class pickdetected : MonoBehaviour {
	public int picknumber;

	// Use this for initialization
	void Start () {

		picknumber = transform.childCount+1;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
