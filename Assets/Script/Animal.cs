using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 基类：Animal
public abstract class Animal : MonoBehaviour // ABSTRACTION
{
    protected bool isGrounded = true;
    private GameObject textCanvas;
    private Slider vitalitySlider;

    // 初始活力值
    private int vitality = 100;

    // 活力减少速率（每秒减少多少点活力）// ENCAPSULATION
    protected int vitalityDecreaseRate;

    public int Vitality // ENCAPSULATION: 提供了受控访问的属性
    {
        get { return vitality; }
        private set
        {
            vitality = Mathf.Clamp(value, 0, 100);
            UpdateVitalityUI();
        }
    }

    void Start()
    {
        InitializeTextCanvas();
        InitializeVitalityUI();
        StartCoroutine(ReduceVitalityOverTime());
    }

    // 初始化TextCanvas // ABSTRACTION
    private void InitializeTextCanvas()
    {
        textCanvas = transform.Find("TextCanvas")?.gameObject;
        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
        }
    }

    // 初始化VitalityUI（能量条）
    private void InitializeVitalityUI()
    {
        vitalitySlider = transform.Find("VitalityCanvas/Slider")?.GetComponent<Slider>();
        if (vitalitySlider != null)
        {
            vitalitySlider.maxValue = 100;
            vitalitySlider.value = vitality;
        }
    }

    // 更新能量条的UI显示
    private void UpdateVitalityUI()
    {
        if (vitalitySlider != null)
        {
            vitalitySlider.value = vitality;
        }
    }

    // 每秒减少活力值的协程
    private IEnumerator ReduceVitalityOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Vitality -= vitalityDecreaseRate; // 每秒减少指定速率的活力值
            Debug.Log($"{gameObject.name} Vitality decreased to: {Vitality}");

            // 停止协程如果活力值达到0
            if (Vitality <= 0)
            {
                yield break;
            }
        }
    }

    // 定义一个抽象的跳跃方法 // ABSTRACTION
    public abstract void Jump();

    private void OnMouseDown()
    {
        if (isGrounded)
        {
            Feed();
            SetTextVisibility(true);
            Jump();
        }
    }

    // 喂食方法，每次点击增加10点活力
    private void Feed()
    {
        Vitality += 40;
        Debug.Log($"{gameObject.name} has been fed. Vitality: {Vitality}");
    }

    // 执行跳跃方法
    protected void PerformJump(float jumpForce)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    // 控制文字显示或隐藏 // ABSTRACTION
    private void SetTextVisibility(bool isVisible)
    {
        if (textCanvas != null)
        {
            textCanvas.SetActive(isVisible);
        }
    }

    // 碰撞检测，用于检测物体是否接触到地面
    private void OnCollisionEnter(Collision collision)
    {
        CheckGroundCollision(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        CheckGroundCollision(collision, false);
    }

    private void CheckGroundCollision(Collision collision, bool isEntering)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = isEntering;
            SetTextVisibility(!isEntering);
        }
    }
}