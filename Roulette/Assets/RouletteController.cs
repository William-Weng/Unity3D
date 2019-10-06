using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotateSpeed = 0;  /* 旋轉的速率 */

    // 這個是一開始的進入點 (只會執行一次)
    void Start() { }

    // 這個一個無限Loop
    void Update()
    {

        /// 按下滑鼠左鍵 / 單點擊手機畫面 => 速度就會改成 10
        if (Input.GetMouseButtonDown(0))
        {
            rotateSpeed = 10;
        }

        /// 開始旋轉
        transform.Rotate(0, 0, rotateSpeed);

        /// 慢慢停下來
        rotateSpeed *= 0.96f;
    }
}
