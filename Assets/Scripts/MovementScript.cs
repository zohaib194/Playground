using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{


    public float speed = 6.0f;
	public float gravity = 10.0f;

	private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
    	rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        float X = Input.GetAxis("Mouse X") * 3;
        this.gameObject.transform.Rotate(0, X, 0);


        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        moveDirection = this.gameObject.transform.rotation * moveDirection;

        // Move the player
        this.gameObject.transform.position += moveDirection * Time.deltaTime;
        
    }
}
