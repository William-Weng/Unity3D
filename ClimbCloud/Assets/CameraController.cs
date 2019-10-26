using UnityEngine;

public class CameraController : MonoBehaviour {

    private readonly string playerObjectName = "cat";

    private GameObject player;

    void Start() {
        InitPlayer();
    }

    void Update() {
        CameraPostion();
    }

    /// 找尋主角物件
    private void InitPlayer() {
        player = GameObject.Find(playerObjectName);
    }

    /// 攝影機的位置 (跟著主角移動)
    private void CameraPostion() {
        Vector3 playerPosition = player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPosition.y, transform.position.z);
    }
}
