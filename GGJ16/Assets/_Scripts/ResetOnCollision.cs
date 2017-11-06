using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetOnCollision : MonoBehaviour {

	public string colliderTag;
	public float restartDelay = 1f;
	public GameObject deathSplosion;
	public GameObject deathOverlay;

	private bool killTriggered;

	void FixedUpdate() {
		if(Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("Main");
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals(colliderTag)) {
			if(!killTriggered) {
				Instantiate(deathSplosion, other.transform.position, Quaternion.identity);
				killTriggered = true;
				deathOverlay.SetActive(true);
				StartCoroutine(loadMainScene(restartDelay));
			}

		}
	}

	public static IEnumerator loadMainScene(float delay) {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("Main");
	}
}
