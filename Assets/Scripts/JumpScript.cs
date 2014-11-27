using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {
	
	public float jumpSpeed = 5f;
	public float superJump = 2;
	public bool standing;
	
	private float initJump;
	void Start(){
		initJump = jumpSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		var absVelY = Mathf.Abs(rigidbody2D.velocity.y);
		if(absVelY <= .05f){
			standing = true;
		}else{
			standing = false;
		}
		
		if( (Input.GetKeyDown("up") || Input.GetKeyDown("space")) && standing){
			rigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
		}
	}
	
	//Si salimos del trigger cortamos la carga
	void OnTriggerExit2D(Collider2D target){
		if (target.transform.tag == "SuperJump") {
			jumpSpeed = initJump;
		}
	}
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.transform.tag == "SuperJump") {
			jumpSpeed = jumpSpeed * superJump;
		}
	}
}