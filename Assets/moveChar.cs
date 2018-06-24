using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChar : MonoBehaviour {

    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform bikeTran;
    private float oldY = 0;
    private float oldDiff = 0;

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 60;
        target = GameObject.Find("targetCube").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = target.position;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.forward * 0.05F;
        float newY = transform.eulerAngles.y;
        float newDiff = newY - oldY;
        Vector3 diff = new Vector3((newDiff + 20*oldDiff)/21, 90+newY, 0);
        GameObject.Find("bike").transform.eulerAngles = diff;
        oldY = newY;
        oldDiff = newDiff;
	}
}
