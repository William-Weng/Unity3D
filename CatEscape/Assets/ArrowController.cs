using UnityEngine;

public class ArrowController : MonoBehaviour {

    private static readonly float dropSpeed = -0.1f;
    private static readonly float boundPositionY = -5.0f;
    private static readonly float playerRadius = 1.0f;
    private static readonly float arrowRadius = 0.5f;

    private static readonly string playIdentity = "player";
    private static readonly string gameDirectorIdentity = "GameDirector";

    GameObject playerObject;

    void Start() {
        playerObject = FindGameObjectWithIdentity(playIdentity);
    }

    void Update() {
        DropArrow();
        ConflictTesting();
    }

    // 讓箭頭往下掉落 (超過畫面就消失)
    private void DropArrow() {
        transform.Translate(0, dropSpeed, 0);
        if (transform.position.y < boundPositionY) { ArrowDestory(); }
    }

    // 利用物件的名字找到該物件
    private GameObject FindGameObjectWithIdentity(string identity) {
        return GameObject.Find(identity);
    }

    // 測試箭頭跟玩家撞到時的反應 (兩者的距離 < 兩者的半徑和 => 箭頭消失 / 損血)
    private void ConflictTesting() {

        Vector2 arrowPosition = transform.position;
        Vector2 playerPosition = playerObject.transform.position;
        Vector2 directionVector = arrowPosition - playerPosition;

        float direction = directionVector.magnitude;
        float conflictRadius = arrowRadius + playerRadius;

        if (direction < conflictRadius) {
            ArrowDestory();
            NoticeDecreaseHp();
        }
    }

    // 箭頭消失
    private void ArrowDestory() {
        Destroy(gameObject);
    }

    // 通知GameDirector要損血了
    private void NoticeDecreaseHp() {
        GameObject gameDirector = FindGameObjectWithIdentity(gameDirectorIdentity);
        gameDirector.GetComponent<GameDirector>().DecreaseHp();
    }
}
