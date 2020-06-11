using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {
	public GameObject target;
    public bool followPlayer = false;
    public float walkDistance = 10.0f;
    public float runDistance = 7.0f;
    public float height = 5.0f;
    public float rotationDamping = 5.0f;
    public float heightDamping = 5.0f;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {   

    }

    void LateUpdate() {
        
        float wantedRotationAngle = target.transform.eulerAngles.y;
        float wantedHeight = target.transform.position.y + height;

        float currentRotationAngle = this.gameObject.transform.eulerAngles.y;
        float currentHeight = this.gameObject.transform.position.y;

        // Damp the rotation around y-axis
        currentRotationAngle = Mathf.LerpAngle(
            currentRotationAngle, 
            wantedRotationAngle, 
            rotationDamping * Time.deltaTime
        );

        currentHeight = Mathf.Lerp(
            currentHeight, 
            wantedHeight, 
            heightDamping * Time.deltaTime
        );  

        // Convert angles into rotation
        Quaternion currentRotation = Quaternion.Euler(0.0f, currentRotationAngle, 0.0f);

        this.gameObject.transform.position = target.transform.position;
        this.gameObject.transform.position -= currentRotation * Vector3.forward * walkDistance;

        this.gameObject.transform.position = new Vector3(
            this.gameObject.transform.position.x, 
            currentHeight,
            this.gameObject.transform.position.z
        );

        this.gameObject.transform.LookAt(target.transform);


        /*this.gameObject.transform.position = new Vector3(
            target.transform.position.x,
            target.transform.position.y + height,
            target.transform.position.z - walkDistance
        );

        this.gameObject.transform.LookAt(target.transform); */
    }
}
