using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowNormal : MonoBehaviour
{
    //跟随的游戏人物
    private Transform player;
    //相机与人物间的距离
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
