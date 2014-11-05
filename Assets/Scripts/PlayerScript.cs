using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(2,3);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

				var absVelX = Mathf.Abs (rigidbody2D.velocity.x);	//Para saber el valor absoluto de algo. En este caso Velocidad en X
				var forceX = 0f;									//var se usa para variables de usar y tirar
				var forceY = 0f;									//Fuerza en ambos ejes
	
				//Calcular Velocity X
				if (Input.GetKey ("right")) {
						if (absVelX < maxVelocity.x)
								forceX = speed;
						this.transform.localScale = new Vector3 (1, 1, 1);
				} else if (Input.GetKey ("left")) {
						if (absVelX < maxVelocity.x)
								forceX = -speed;
						this.transform.localScale = new Vector3 (-1, 1, 1);
				}
				rigidbody2D.AddForce (new Vector2 (forceX, forceY));


	}
}
