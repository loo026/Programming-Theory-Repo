using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startCanvas; // 引用开始界面 Canvas
    public static bool isGameStarted = false; // 静态变量，表示游戏是否已经开始

    void Start()
    {
        // 确保游戏一开始时显示开始界面
        if (startCanvas != null)
        {
            startCanvas.SetActive(true);
        }
    }

    // 开始游戏的方法
    public void StartGame()
    {
        // 隐藏开始界面
        if (startCanvas != null)
        {
            startCanvas.SetActive(false);
        }

        // 设置游戏开始标志
        isGameStarted = true;
        Debug.Log("Game Started!");
    }
}
