using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    //旋转速度
    public float turnSpeed = 20f;
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    //移动向量
    private Vector3 m_Movement;
    //旋转角度
    private Quaternion m_Quaternion = Quaternion.identity;

    private void Start()
    {
        //获取人物身上的组件
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //获取X轴、Z轴方向是否有键值输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //设置游戏人物移动方向
        m_Movement.Set(horizontal, 0, vertical);
        m_Movement.Normalize();

        //定义游戏人物是否移动的布尔值
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        //如果人物移动，播放移动动画
        m_Animator.SetBool("IsWalking", isWalking);

        //旋转的过渡
        //通过三元数转四元数的方式获取游戏人物当前的目标角度
        Vector3 desirForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0);
        m_Quaternion = Quaternion.LookRotation(desirForward);
    }

    //游戏人物的移动和旋转
    private void OnAnimatorMove()
    {
        //m_Rigidbody.MovePosition()
        //通过提供坐标让rb移动起来
        //当前位置 + 移动向量
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Quaternion);
    }
}
