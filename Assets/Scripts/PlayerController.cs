using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float grondCheck;
	private int count;
	public float fly;
	public GUIText countText;
	public GUIText winText;
	private bool jumpControl;
	void Start ()
	{
		jumpControl = true;
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

		groundCheck ();
		if (jumpControl) {
		
			if(Input.GetButton("Jump"))
			{
				rigidbody.AddForce (jump*Time.deltaTime);
				jumpControl=false;
			}
		
		
		}

	
	}

	void groundCheck (){
	
	
		RaycastHit hit;
		Ray isground = new Ray (transform.position, Vector3.down);

		if (Physics.Raycast(isground, out hit,grondCheck)) {

			jumpControl=true;


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





	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 8) 
		{
			winText.text="YOU WıN!";
			gameObject.renderer.material.color=Color.blue;
		}


	}


}
//Destroy (other.gameObject);
//gameObject.tag="Player";
//gameObject.SetActive(false);