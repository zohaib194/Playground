using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(player) {
	        Vector3 positionToPlayer = player.transform.position - this.gameObject.transform.position;

    		this.gameObject.transform.position += positionToPlayer * Time.deltaTime;
    		this.gameObject.transform.Rotate(0.0f, positionToPlayer.y, 0.0f);
    	}

    }

    void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.name == "ball") {
			Destroy(gameObject);
    	}
    }
}
