using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal // INHERITANCE: Cat继承自Animal
{
    void Awake()
    {
        vitalityDecreaseRate = 5; // Cat 每秒减少5点活力值
    }

    public override void Jump() // POLYMORPHISM: 重写父类的Jump方法
    {
        Debug.Log("Cat jumps gracefully.");
        PerformJump(5);
    }
}
