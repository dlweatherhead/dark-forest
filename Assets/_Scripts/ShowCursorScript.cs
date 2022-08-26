using UnityEngine;
using System.Collections;

public class ShowCursorScript : MonoBehaviour {

	public UIMainMenuFunctions mainFunctions;

	void Start () {
		Cursor.visible = true;
	}

	void FixedUpdate() {
		if(Input.GetKey(KeyCode.Escape)) {
			mainFunctions.QuitGame();
		}

		if(Input.GetKey(KeyCode.I)) {
			mainFunctions.ShowInfoScreen();
		}

		if(Input.GetKey(KeyCode.Space)) {
			mainFunctions.StartGame();
		}

		if(Input.GetKey(KeyCode.B)) {
			mainFunctions.showMainScreen();
		}
	}
}
