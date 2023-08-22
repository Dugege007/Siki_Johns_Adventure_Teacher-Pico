using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointsPatrol : MonoBehaviour
{
    //导航组件
    private NavMeshAgent navMeshAgent;
    //导航点的数组
    public Transform[] wayPoints;

    //当前巡逻的目标点
    private int m_CurrentPointIndex;

    private void Start()
    {
        //获取组件
        navMeshAgent = GetComponent<NavMeshAgent>();
        //从起点到达第一个巡逻点
        navMeshAgent.SetDestination(wayPoints[0].position);
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance<navMeshAgent.stoppingDistance)
        {
            //到达目标点，前往下一个目标点
            m_CurrentPointIndex=(m_CurrentPointIndex + 1) % wayPoints.Length;
            navMeshAgent.SetDestination(wayPoints[m_CurrentPointIndex].position);
        }
    }
}
