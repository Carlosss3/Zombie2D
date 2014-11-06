using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float damping = 1;			// Amortiguacion
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float yPosRestiction = -1;

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	// Use this for initialization
	void Start () {

		lastTargetPosition = target.position;				//Posicion del Target almacenada en lastTargetPosition
		offsetZ = (transform.position - target.position).z;	// Diferencia entre la posiscion de la camara y la del target en z
		transform.parent = null;
	
	}
	
	// Update is called once per frame
	void Update () {
		//only update loohAhead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;		//Para detectar el movimiento del Target
		
		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;	//Para detectar movimiento del Target
		
		if (updateLookAheadTarget) {											//Para actualizar hacia donde mira el Target (en caso de que haya movimiento detectado
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping); //Posicion actual, posicion a donde queremos llegar, velocidad
																								// actual (modificada por la funcion) y el tiempo aproximado que tardara en 
																								// llegar a la posicionj final (target) o amortiguacion
		
		newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y,yPosRestiction,Mathf.Infinity), newPos.z); // Le damos un max y un min en el eje ordenadas por si el target se aleja
		transform.position = newPos; // Asignamos el valor de la nueva posicion
		
		lastTargetPosition = target.position; //Y pasamos la nueva posicion para volver a repetir el proceso.
	
	}
}
