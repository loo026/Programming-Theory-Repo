using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal // INHERITANCE: Dog继承自Animal
{
    void Awake()
    {
        vitalityDecreaseRate = 10; // Dog 每秒减少3点活力值
    }

    public override void Jump() // POLYMORPHISM: 重写父类的Jump方法
    {
        Debug.Log("Dog jumps energetically.");
        PerformJump(4);
    }
}

