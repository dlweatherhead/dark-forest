using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetOnCollision : MonoBehaviour {

	public string colliderTag;
	public GameObject deathSplosion;
	public float restartDelay = 1f;

	private bool killTriggered = false;

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals(colliderTag)) {
			if(!killTriggered) {
				Instantiate(deathSplosion, other.transform.position, Quaternion.identity);
				killTriggered = true;
				StartCoroutine(loadMainScene(restartDelay));
			}

		}
	}

	public static IEnumerator loadMainScene(float delay) {
		yield return new WaitForSeconds(delay);
		// Reset the level.
		SceneManager.LoadScene("Main");
	}
}
