using UnityEngine;

public class ArrowGenerator : MonoBehaviour {

    public GameObject arrowPrefab;

    private static readonly int minRandomX = -6;
    private static readonly int maxRandomX = 7;
    private static readonly float height = 7.0f;
    private static readonly float spanTime = 1.0f;

    private float deltaTime;

    void Update() { ArrowMaker(); }

    // 產生箭頭 (定時產生)
    private void ArrowMaker() {

        deltaTime += Time.deltaTime;

        if (deltaTime > spanTime) {

            deltaTime = 0;

            GameObject arrowObject = Instantiate(arrowPrefab) as GameObject;
            arrowObject.transform.position = RandomVector3(minRandomX, maxRandomX);
        }
    }

    // 產生不同的位置
    private Vector3 RandomVector3(int min, int max) {
        int randomX = Random.Range(min, max);
        return new Vector3(randomX, height, 0);
    }
}
