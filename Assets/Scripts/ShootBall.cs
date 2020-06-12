using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public GameObject ball;
    public float force = 10;

    private float nextFire = 0;
    // Start is called before the first frame update
    void Start()
    {
     //   ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {

            Vector3 ballPosition = new Vector3(
            	this.gameObject.transform.position.x, 
            	this.gameObject.transform.position.y + 0.5f, 
            	this.gameObject.transform.position.z + 0.3f
            ) + transform.rotation * Vector3.forward;
            
            GameObject obj = Instantiate(ball, ballPosition, this.gameObject.transform.rotation) as GameObject;

        	obj.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * force);

            obj.name = "ball";
            Destroy(obj, 5);
        }
    }


}