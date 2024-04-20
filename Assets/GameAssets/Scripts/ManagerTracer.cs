using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManagerTracer : MonoBehaviour
{
    [SerializeField]
    private ManagerData managerData;
    [SerializeField]
    private Transform navTarget;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        this.navMeshAgent.speed = this.managerData.speed;
        this.navMeshAgent.destination = this.navTarget.position;
    }
}
