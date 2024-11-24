using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    [SerializeField] private List<Transform> path;
    [SerializeField] private float acceptableDistance;
    [SerializeField] private GameObject mainMenu;
    private int currentTarget;
    private NavMeshAgent agent;
    private bool chasingPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = path[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - agent.destination).magnitude <= acceptableDistance)
        {
            if (chasingPlayer)
            {

            }
            else
            {
                setNextDestination();
            }
        }
    }

    private void setNextDestination()
    {
        currentTarget = (currentTarget + 1) % path.Count;
        agent.destination = path[currentTarget].position;
    }


}
