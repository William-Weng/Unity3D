using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDircetor : MonoBehaviour {

    private readonly string sceneName = "GameScene";

	void Update() {
		changeScene();
	}

    // 切換場景
    private void changeScene() {
		if (Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene(sceneName);
		}
	}
}
