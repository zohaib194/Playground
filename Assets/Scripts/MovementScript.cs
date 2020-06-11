using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    CharacterController characterController;

    public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 10.0f;

	private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
    	characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 characterPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        mousePos.x = characterPosition.x - mousePos.x;
        mousePos.y = characterPosition.y - mousePos.y;
 
        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
       
    	if(characterController.isGrounded) {


			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

			if(Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
    	}

    	moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
