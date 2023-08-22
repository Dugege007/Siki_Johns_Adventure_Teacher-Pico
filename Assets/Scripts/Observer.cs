using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //��Ϸ���
    public Transform player;
    //GameEnding
    public GameEnding gameEnding;

    //����Ƿ���뵽ɨ�����߷�Χ
    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        //ɨ�赽��ҽ�������
        if (other.gameObject==player.gameObject)
        {
            isInRange= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //ɨ�赽����뿪����
        if (other.gameObject == player.gameObject)
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            //���߼��
            Vector3 dir = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.transform==player)
                {
                    //��ұ�ץץ����Ϸʧ��
                    gameEnding.Caught();
                }
            }
        }
    }
}
