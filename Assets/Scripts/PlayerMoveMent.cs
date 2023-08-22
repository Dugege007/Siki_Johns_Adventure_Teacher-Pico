using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    //��ת�ٶ�
    public float turnSpeed = 20f;
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    //�ƶ�����
    private Vector3 m_Movement;
    //��ת�Ƕ�
    private Quaternion m_Quaternion = Quaternion.identity;

    private void Start()
    {
        //��ȡ�������ϵ����
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //��ȡX�ᡢZ�᷽���Ƿ��м�ֵ����
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //������Ϸ�����ƶ�����
        m_Movement.Set(horizontal, 0, vertical);
        m_Movement.Normalize();

        //������Ϸ�����Ƿ��ƶ��Ĳ���ֵ
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        //��������ƶ��������ƶ�����
        m_Animator.SetBool("IsWalking", isWalking);

        //��ת�Ĺ���
        //ͨ����Ԫ��ת��Ԫ���ķ�ʽ��ȡ��Ϸ���ﵱǰ��Ŀ��Ƕ�
        Vector3 desirForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0);
        m_Quaternion = Quaternion.LookRotation(desirForward);
    }

    //��Ϸ������ƶ�����ת
    private void OnAnimatorMove()
    {
        //m_Rigidbody.MovePosition()
        //ͨ���ṩ������rb�ƶ�����
        //��ǰλ�� + �ƶ�����
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Quaternion);
    }
}
