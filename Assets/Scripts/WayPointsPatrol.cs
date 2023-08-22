using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointsPatrol : MonoBehaviour
{
    //�������
    private NavMeshAgent navMeshAgent;
    //�����������
    public Transform[] wayPoints;

    //��ǰѲ�ߵ�Ŀ���
    private int m_CurrentPointIndex;

    private void Start()
    {
        //��ȡ���
        navMeshAgent = GetComponent<NavMeshAgent>();
        //����㵽���һ��Ѳ�ߵ�
        navMeshAgent.SetDestination(wayPoints[0].position);
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance<navMeshAgent.stoppingDistance)
        {
            //����Ŀ��㣬ǰ����һ��Ŀ���
            m_CurrentPointIndex=(m_CurrentPointIndex + 1) % wayPoints.Length;
            navMeshAgent.SetDestination(wayPoints[m_CurrentPointIndex].position);
        }
    }
}
