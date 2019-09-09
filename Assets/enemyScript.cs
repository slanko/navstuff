using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    NavMeshAgent nav;
    public List<Transform> patrolTargets;
    int currentTarget;
    public float dtd, distThreshold;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(patrolTargets[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        dtd = Vector3.Distance(patrolTargets[currentTarget].transform.position, transform.position);
        if(dtd < distThreshold)
        {
            nextNode();
        }
    }

    void nextNode()
    {
        currentTarget++;
        if(currentTarget > patrolTargets.Count - 1)
        {
            currentTarget = 0;
        }
        nav.SetDestination(patrolTargets[currentTarget].transform.position);

    }


}
