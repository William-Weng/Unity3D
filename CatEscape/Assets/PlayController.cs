using UnityEngine;

public class PlayController : MonoBehaviour {

    private static readonly float moveSpeed = 3.0f;

    void Update() { MovePlayerWithKey(); }

    // 利用鍵盤左右鍵來移動Player
    private void MovePlayerWithKey() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { MovePlayerWithSpeed(-moveSpeed); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { MovePlayerWithSpeed(moveSpeed); }
    }

    // 利用右按鍵來移動Player (公開的函式)
    public void MovePlayerWithRightButton() {
        MovePlayerWithSpeed(-moveSpeed);
    }

    // 利用左按鍵來移動Player (公開的函式)
    public void MovePlayerWithLeftButton() {
        MovePlayerWithSpeed(moveSpeed);
    }

    // 移動Player (速度)
    private void MovePlayerWithSpeed(float speed) {
        transform.Translate(speed, 0, 0);
    }
}
