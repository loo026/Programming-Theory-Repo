using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{
    public override void Jump()
    {
        Debug.Log("Cow jumps heavily.");
        // 添加跳跃逻辑，例如使用刚体增加向上的力
        GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
        isGrounded = false;
    }
}

