using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;

    void Start()
    {
        InitGameObject();
    }

    void Update()
    {
        FinishTesting();
    }

    // 先找到畫面上的物件在哪裡 (名字就是在屬性表上看到的名字)
    private void InitGameObject()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
    }

    // 測試車子有沒有到終點 (GetComponent()的使用)
    private void FinishTesting()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;

        if (length > 0) {
            this.distance.GetComponent<Text>().text = "距離目標還有 " + length.ToString("F2") + " 公尺";
        } else {
            this.distance.GetComponent<Text>().text = "抵達終點";
        }
    }
}
