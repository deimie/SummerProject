using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMovement : MonoBehaviour
{
    public Transform crystal; //reference to crystal (target)
    private NavMeshAgent agent; //reference to NavMeshAgent

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //get the NMA attached to this enemy
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = crystal.position; //sets the agent destination to crystal position
    }
}
