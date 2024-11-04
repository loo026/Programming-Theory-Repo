using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    protected bool isGrounded = true; // 用于检测物体是否在地面上

    // 定义一个抽象的跳跃方法
    public abstract void Jump();

    private void OnMouseDown()
    {
        // 只有在isGrounded为true时才允许跳跃
        if (isGrounded)
        {
            Jump();
        }
    }

    // 检测物体是否接触到地面
    private void OnCollisionEnter(Collision collision)
    {
        // 确保碰到的是地面，这里假设地面有标签 "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}


