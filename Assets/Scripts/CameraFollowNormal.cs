using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowNormal : MonoBehaviour
{
    //�������Ϸ����
    private Transform player;
    //����������ľ���
    private Vector3 offset;

    private void Start()
    {
        player = GameObject.Find("JohnLemon").transform;
        offset = transform.position - player.position;
    }

    private void Update()
    {
        transform.position = offset + player.position;
    }
}
