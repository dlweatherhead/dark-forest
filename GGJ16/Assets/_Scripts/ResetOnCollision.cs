using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetOnCollision : MonoBehaviour {

	public string colliderTag;
	public GameObject deathSplosion;
	public float restartDelay = 1f;

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals(colliderTag)) {
			Instantiate(deathSplosion, other.transform.position, Quaternion.identity);

			StartCoroutine(loadMainScene(restartDelay));
		}
	}

	public static IEnumerator loadMainScene(float delay) {
		yield return new WaitForSeconds(delay);
		// Reset the level.
		SceneManager.LoadScene("Main");
	}
}
