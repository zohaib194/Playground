using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
	public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(this.gameObject.transform.position.x, 
        									this.gameObject.transform.position.y + 10.0f, 
        									this.gameObject.transform.position.z - 10.0f);
    }
}
