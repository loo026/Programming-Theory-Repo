using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal // INHERITANCE: Cow继承自Animal
{
    void Awake()
    {
        vitalityDecreaseRate = 15; // Cow 每秒减少2点活力值
    }

    public override void Jump() // POLYMORPHISM: 重写父类的Jump方法
    {
        Debug.Log("Cow jumps heavily.");
        PerformJump(3);
    }
}

