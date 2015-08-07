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
	public float airspeed;
	private bool jumpControl;
	private int pickles;
	private int loadedlvl;
	//private Vector3 startPos;


	private float redSpeed=1000;

	private int dblJump=0;
	private bool blueBuff=false;

	private bool redBuff=false;


	void Start ()
	{

		//startPos = transform.position;
		loadedlvl = Application.loadedLevel;
		HowManyPickups ();
		Debug.Log (pickles);

		count = 0;
		SetCountText();
		winText.text="";

	}





	void FixedUpdate(){
	

		RestartLevel ();

		groundCheck ();

		Movements ();
		GreenBuff ();
		BlueBuff ();
	


	
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
	void BlueBuff(){
	
		if (GetComponent<Rigidbody> ().velocity.y < 0 && gameObject.GetComponent<Renderer> ().material.color == Color.blue )
			blueBuff = true;
		else
			blueBuff = false;
	
	
	
	}

	void GreenBuff(){
	
		if (gameObject.GetComponent<Renderer> ().material.color == Color.green && jumpControl)
			dblJump = 1;
		else if(gameObject.GetComponent<Renderer> ().material.color != Color.green)
			dblJump = 0;
	
	
	
	}




	void Movements(){
	
	
		float moveHorizontal =Input.GetAxis("Horizontal");
		float moveVertical= Input.GetAxis("Vertical");
		
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 jump = new Vector3 (0.0f, fly, 0.0f);

	
		if (jumpControl) {
			
			GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
			
			if (Input.GetButtonDown ("Jump")) {
				GetComponent<Rigidbody> ().AddForce (jump * Time.deltaTime);
				
				jumpControl = !jumpControl;
				
			}

			
			
		}  

		else{


			GetComponent<Rigidbody> ().AddForce (movement * airspeed * Time.deltaTime);
		if (dblJump>0) {
		
			if (Input.GetButtonDown ("Jump")) {


				GetComponent<Rigidbody> ().AddForce (jump * Time.deltaTime);
				dblJump --;
			
			}

		} else if ( blueBuff) {
		
		
			if(Input.GetButton("Jump"))
				GetComponent<Rigidbody> ().AddForce (jump *0.02f * Time.deltaTime);

		
		
		}

	
	
	 }
		if (redBuff) {

			GetComponent<Rigidbody> ().AddForce (movement * redSpeed* Time.deltaTime,ForceMode.Impulse);
			redBuff=!redBuff;
		
		}
	}




	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUpRed") {
			redBuff=true;
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			gameObject.GetComponent<Renderer> ().material.color = Color.red;


		} else if (other.gameObject.tag == "PickUpGreen") {
			dblJump=2;
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		} else if (other.gameObject.tag == "PickUpBlue") {
		
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
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