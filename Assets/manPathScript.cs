using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manPathScript : MonoBehaviour
{

    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;


    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
        //target = GameObject.Find("MainChar").transform;
        //agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("MainChar").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = target.position;
        Debug.Log(agent.remainingDistance);
        if (agent.remainingDistance > 3.0 && agent.remainingDistance < 5.0) {
            GameObject.Find("rpm").GetComponent<TextMesh>().text = "Game Over";
            GameObject.Find("heartRate").GetComponent<TextMesh>().text = "Game Over";
        }
    }
}
