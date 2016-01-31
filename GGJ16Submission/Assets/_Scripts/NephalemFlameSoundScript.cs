using UnityEngine;
using System.Collections;

public class NephalemFlameSoundScript : MonoBehaviour {

	public AudioClip pickUpClip;

	private AudioSource audioSource;

	void Awake() {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			audioSource.clip = pickUpClip;
			audioSource.Play();

			//AudioSource.PlayClipAtPoint(pickUpClip, gameObject.transform.position);

			transform.position = new Vector3(0f,-1000f,0f);

			StartCoroutine(DestroyFlame(pickUpClip.length));
		}
	}

	IEnumerator DestroyFlame(float delay) {
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);
	}
}
