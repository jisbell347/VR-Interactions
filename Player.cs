using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 0.5f;

    public Vector3 castlePosition;

    public bool enteredCastle;
    // target position of the player
    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	    targetPosition = transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
        // Look at the door
	    RaycastHit hit;
        // Sends out a raycast in the forward direction and if it hits the Door Button component, calls the OnLook method from the Door Button Class.
	    if (Physics.Raycast(transform.position, transform.forward, out hit)) {
	        if (hit.transform.GetComponent<DoorButton>() != null) {
                hit.transform.GetComponent<DoorButton>().OnLook();
                MoveToCastle();
	        }
	    }

        //Shooting at enemies
	    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space")) {
	        RaycastHit enemyHit;
	        if (Physics.Raycast(transform.position, transform.forward, out enemyHit)) {
	            if (hit.transform.GetComponent<Enemy>() != null) {
                    Destroy(hit.transform.gameObject);
	            }
	        }
	    }

        //Moving Logic
	    transform.parent.position = Vector3.Lerp(transform.parent.position, targetPosition, Time.deltaTime * speed);
     }

    private void MoveToCastle() {
        enteredCastle = true;
        targetPosition = castlePosition;
    }
}
