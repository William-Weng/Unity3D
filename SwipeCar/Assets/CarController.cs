using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed;
    Vector2 startPosition;

    void Update() { MoveCarWithMouse(); }

    // 使用滑鼠移動車子
    private void MoveCarWithMouse()
    {
        // 按下滑鼠左鍵
        if (Input.GetMouseButtonDown(0))
        {
            this.startPosition = Input.mousePosition;
        }

        // 放開滑鼠左鍵 => 根據兩者的差距決定速度
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPosition = Input.mousePosition;
            float swipeLength = endPosition.x - this.startPosition.x;
            this.speed = swipeLength / 500.0f;

            PlaySound();
        }

        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
    }

    // 播放音效
    private void PlaySound() {
        GetComponent<AudioSource>().Play();
    }
}
