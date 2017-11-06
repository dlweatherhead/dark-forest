using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuFunctions : MonoBehaviour {

	public GameObject startGameButton;
	public GameObject infoButton;
	public GameObject quitButton;
	public GameObject infoText;
	public GameObject backButton;

	void Start() {		
		Cursor.visible = true;
	}

	public void StartGame() {
		SceneManager.LoadScene("Level");
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void ShowInfoScreen() {
		startGameButton.SetActive(false);
		infoButton.SetActive(false);
		quitButton.SetActive(false);

		infoText.SetActive(true);
		backButton.SetActive(true);
	}

	public void showMainScreen() {
		infoText.SetActive(false);
		backButton.SetActive(false);

		startGameButton.SetActive(true);
		infoButton.SetActive(true);
		quitButton.SetActive(true);
	}
}
