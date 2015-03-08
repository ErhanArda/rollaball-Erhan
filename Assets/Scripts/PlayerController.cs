using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{   
	public GameObject mahmut;
	public float speed;
	public float grondCheck;
	private int count;
	public float fly;
	public GUIText countText;
	public GUIText winText;
	private bool jumpControl;
	private int pickles;
	private int loadedlvl;
	//private Vector3 startPos;

	void Start ()
	{

		//startPos = transform.position;
		loadedlvl = Application.loadedLevel;
		HowManyPickups ();
		Debug.Log (pickles);
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

		RestartLevel ();


		groundCheck ();
		if (jumpControl) {
		
			GetComponent<Rigidbody>().AddForce (movement*speed*Time.deltaTime);

			if(Input.GetButton("Jump"))
			{
				GetComponent<Rigidbody>().AddForce (jump*Time.deltaTime);
				jumpControl=false;
			}
		
		
		}

	
	}

	void RestartLevel(){

	
		if (transform.position.y < -5) {
			
			
			Application.LoadLevel (loadedlvl);
			//transform.position= startPos;
			
		}

	
	
	}
	void HowManyPickups(){
		pickles = mahmut.transform.childCount;

	
	
	
	
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
			count=count + 1;
			SetCountText();


		}
	
	
}





	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count == pickles) 
		{
			winText.text="You Win!";
			gameObject.GetComponent<Renderer>().material.color=Color.blue;
		}


	}


}
//Destroy (other.gameObject);
//gameObject.tag="Player";
//gameObject.SetActive(false);