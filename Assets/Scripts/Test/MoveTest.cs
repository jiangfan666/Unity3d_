using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float moveDistance = 10.0f; // 移动距离
    public float startTime = 0.0f; // 开始时间
    public float endTime = 5.0f; // 结束时间
    public float speed = 10.0f; // 速度

    private float timer; // 计时器

    void Start()
    {
        timer = startTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= endTime)
        {
            return;
        }

        float progress = Mathf.PingPong(timer, endTime - startTime) * speed; // 非线性进度
        transform.position += new Vector3(progress, 0, 0); // 沿x轴移动
    }
}
