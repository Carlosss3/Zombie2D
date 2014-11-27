using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	public float speed = 0.4f;
	public Transform checkMuros, checkSuelos;
	private bool veomuro = false;
	private bool veosuelo = true;
	private bool alterado = false;
	private Vector2  direction;
	public float velocidad;
	
	
	// Use this for initialization
	public float tiempo_espera = 0;
	
	void Start () {
		
	}
	
	void Update () {
		
		gira_si_no_avanza();
		gira_si_veo_muro();
		gira_si_no_hay_suelo();
		
		busca_player();
		
		rigidbody2D.velocity = new Vector2(this.transform.localScale.x * speed, rigidbody2D.velocity.y);
		
	}
	
	
	
	void mediavuelta(){
		this.transform.localScale = new Vector3(this.transform.localScale.x * -1, 1, 1);
	}
	
	void gira_si_no_avanza(){
		velocidad =  Mathf.Abs (rigidbody2D.velocity.x);
		if(velocidad < 0.1f && !alterado){
			if(tiempo_espera == 0){
				tiempo_espera = Time.time + 3;
			}else if(tiempo_espera < Time.time){
				tiempo_espera = 0;
				mediavuelta();
			}
		}
		
	}
	
	void gira_si_veo_muro(){
		veomuro = Physics2D.Linecast (transform.position, checkMuros.position, 1 << LayerMask.NameToLayer ("Ground"));
		Debug.DrawLine (transform.position, checkMuros.position,Color.green);
		if (veomuro)
			mediavuelta();
	}
	
	void gira_si_no_hay_suelo(){
		veosuelo = Physics2D.Linecast (transform.position, checkSuelos.position, 1 << LayerMask.NameToLayer ("Ground"));
		Debug.DrawLine (transform.position, checkSuelos.position,Color.red);
		if (!veosuelo)
			mediavuelta();
	}
	
	void busca_player(){
		direction  = checkMuros.position-transform.position;
		var ray = new Ray2D(transform.position,direction.normalized);
		//Debug.DrawRay(ray.origin, ray.direction*2);
		var hit = Physics2D.Raycast(ray.origin, ray.direction,2, 1 << LayerMask.NameToLayer ("Player"));
		if (hit.collider != null && hit.transform.tag == "Player") {
			speed = 2;
			alterado =true;
		}else{
			speed = 0.4f;
			alterado = false;
		}
	}
}