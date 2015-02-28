using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private int count;
	public float fly;
	public GUIText countText;
	public GUIText winText;
	private bool jumpControl;
	void Start ()
	{
		count = 0;
		SetCountText();
		winText.text="";
	}

	void FixedUpdate(){
	
		float moveHorizontal =Input.GetAxis("Horizontal");
		float moveVertical= Input.GetAxis("Vertical");
	

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 jump = new Vector3 (0.0f, fly, 0.0f);

		rigidbody.AddForce (movement*speed*Time.deltaTime);

		if (jumpControl) {
		
			if(Input.GetButton("Jump"))
			{
				rigidbody.AddForce (jump*Time.deltaTime);
			}
		
		
		}





	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count=count+1;
			SetCountText();


		}
	
	
}
	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.tag == "Ground") {
			Debug.Log("Player touched");
			jumpControl=true;

		}
	}

	void OnCollisionExit(Collision other){
	
		if (other.gameObject.tag == "Ground") {
			Debug.Log ("Player Untouched");
			jumpControl = false;
	
		}	
	}


	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 8) 
		{
			winText.text="YOU WıN!";
		}
	}


}
//Destroy (other.gameObject);
//gameObject.tag="Player";
//gameObject.SetActive(false);