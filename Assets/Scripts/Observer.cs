using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //游戏玩家
    public Transform player;
    //GameEnding
    public GameEnding gameEnding;

    //玩家是否进入到扫描视线范围
    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        //扫描到玩家进入视线
        if (other.gameObject==player.gameObject)
        {
            isInRange= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //扫描到玩家离开视线
        if (other.gameObject == player.gameObject)
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            //射线检测
            Vector3 dir = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.transform==player)
                {
                    //玩家被抓抓，游戏失败
                    gameEnding.Caught();
                }
            }
        }
    }
}
