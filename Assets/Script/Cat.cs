using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public override void Jump()
    {
        Debug.Log("Cat jumps gracefully.");
        // 添加跳跃逻辑，例如使用刚体增加向上的力
        GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        isGrounded = false;
    }
}

