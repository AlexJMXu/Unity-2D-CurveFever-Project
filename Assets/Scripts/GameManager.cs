using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private bool hasEnded = false;

	void Awake() {
		if (instance != null) {
			Debug.LogError("Already another instance of GameManager in scene.");
			return;
		} else {
			instance = this;
		}
	}

	public void EndGame() {
		if (!hasEnded) StartCoroutine(PlayerEndGameAnimation());
		hasEnded = true;
	}

	private IEnumerator PlayerEndGameAnimation() {
		Debug.Log("Game Over.");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
