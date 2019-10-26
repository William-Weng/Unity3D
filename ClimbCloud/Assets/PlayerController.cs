using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private readonly float jumpForce = 300.0f;
    private readonly float walkForce = 10.0f;
    private readonly float maxWalkForce = 2.0f;

    private readonly string trigger = "JumpTrigger";
    private readonly string sceneName = "ClearScene";

    private new Rigidbody2D rigidbody2D;
    private Animator animator;

    void Start() { InitSetting(); }

    void Update() {
        PlayerMove(walkForce);
        PlayerJump(jumpForce);
    }

    // @override => 碰到旗子的話，就回到首頁
    private void OnTriggerEnter2D(Collider2D collision) {
        GotoClearScene();
    }

    // 讓主角左右移動 (往左右推 / 限制最高速)
    private void PlayerMove(float force) {

        int direction = 0;
        float speedX = Mathf.Abs(rigidbody2D.velocity.x);

        if (Input.GetKey(KeyCode.RightArrow)) { direction = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { direction = -1; }

        if (speedX < maxWalkForce) {
            rigidbody2D.AddForce(transform.right * direction * force);
        }

        PlayerMoveDirection(direction);
        WalkAnimatorSpeed(speedX);
    }

    // 讓主角向上跳 (往上推 / 防止兩段跳 / 切換動畫Trigger / 掉下去回到首頁)
    private void PlayerJump(float force) {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if (IsVelocityZero(rigidbody2D.velocity.y)) {
                animator.SetTrigger(trigger);
                rigidbody2D.AddForce(transform.up * force);
            }
        }

        if (transform.position.y < -10) {
            GotoClearScene();
        }
    }

    // 初始的一些設定 (先找出相關物件的位置)
    private void InitSetting() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // 測試速度是否為0？
    private bool IsVelocityZero(float velocity) {
        return Mathf.Approximately(velocity, 0);
    }

    // 主角移動的圖形位置 (圖片翻轉)
    private void PlayerMoveDirection(int direction) {

        if (direction != 0) {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    // 走路 / 彈跳的動畫速度
    private void WalkAnimatorSpeed(float speed) {

        if (IsVelocityZero(rigidbody2D.velocity.y)) {
            animator.speed = speed * 0.5f;
        } else {
            animator.speed = 1.0f;
        }
    }

    // 回到首頁
    private void GotoClearScene() {
        SceneManager.LoadScene(sceneName);
    }
}
