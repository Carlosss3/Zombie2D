using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(2,3);
	public Light linterna;
	private Animator animator;		// PARA CONTROLAR LA ANIMACION HAY QUE PONER ESTA LINEA

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();	// PARA CONTROLAR LA ANIMACION HAY QUE PONER ESTA LINEA
	
	}
	
	// Update is called once per frame
	void Update () {

				var absVelX = Mathf.Abs (rigidbody2D.velocity.x);	//Para saber el valor absoluto de algo. En este caso Velocidad en X
				var forceX = 0f;									//var se usa para variables de usar y tirar
				var forceY = 0f;									//Fuerza en ambos ejes
	
				//Calcular Velocity X
				if (Input.GetKey ("right")) {
						if(rigidbody2D.velocity.x < 0){
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);  //Esto frena cuando voy a la izquierda y pulso la derecha
			}
						if (absVelX < maxVelocity.x)
								forceX = speed;
						this.transform.localScale = new Vector3 (1, 1, 1); // Esto pone el sprite mirando hacia donde miraba originalmente
				
		
			} else if (Input.GetKey ("left")) {
			if(rigidbody2D.velocity.x > 0)
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);

						if (absVelX < maxVelocity.x)
								forceX = -speed;
						this.transform.localScale = new Vector3 (-1, 1, 1); // Esto pone el sprite mirando hacia el lado contrario
				}

		if (absVelX > 0)
						animator.SetFloat ("Velocity", absVelX);

				rigidbody2D.AddForce (new Vector2 (forceX, forceY));

		if (Input.GetKey (KeyCode.C)) {
						animator.SetBool ("Fire", true);
				} else {
						animator.SetBool ("Fire", false);
				}

	}
}
