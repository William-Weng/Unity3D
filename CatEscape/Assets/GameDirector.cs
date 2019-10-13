using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    private static readonly string hpGaugeIdentity = "hpGauge";
    private static readonly float decreaseHpRate = 0.1f;

    GameObject hpGauge;

    void Start() { hpGauge = FindGameObjectWithIdentity(hpGaugeIdentity); }

    // 利用物件的名字找到該物件
    private GameObject FindGameObjectWithIdentity(string identity) {
        return GameObject.Find(identity);
    }

    // 損血的處理 (公開的函式)
    public void DecreaseHp() {
        hpGauge.GetComponent<Image>().fillAmount -= decreaseHpRate;
    }
}
