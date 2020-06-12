using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{

	public GameObject ai;
	public GameObject player;
	public float period = 1.0f;

	private GameObject plane;
	private float nextActionTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 min = plane.GetComponent<MeshFilter>().mesh.bounds.min;
		Vector3 max = plane.GetComponent<MeshFilter>().mesh.bounds.max;
		Vector3 position = plane.transform.position -  new Vector3 ((Random.Range(min.x, max.x)), plane.transform.position.y, (Random.Range(min.z, max.z)));
    	
    	if (Time.time > nextActionTime ) {
			nextActionTime += period;
    		GameObject enemy = Instantiate(ai, position, Quaternion.identity) as GameObject;
    		AI script = enemy.AddComponent<AI>();
    		script.player = player;
		}

    }
}
