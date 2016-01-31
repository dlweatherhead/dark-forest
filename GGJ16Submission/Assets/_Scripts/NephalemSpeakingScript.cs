using UnityEngine;
using System.Collections;

public class NephalemSpeakingScript : MonoBehaviour {

	public NephalemCollector player;
	public int flamesRequired;

	public AudioClip ritualCompleteClip;
	public AudioClip needMoreFlameClip;

	private AudioSource audioSource;

	void Awake() {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			if(player.flamesCollected() == flamesRequired) {

				audioSource.clip = ritualCompleteClip;
				audioSource.Play();

				//AudioSource.PlayClipAtPoint(ritualCompleteClip, gameObject.transform.position);

				StartCoroutine(ResetOnCollision.loadMainScene(ritualCompleteClip.length + 1f));
			}
			else {
				audioSource.clip = needMoreFlameClip;
				audioSource.Play();

				//AudioSource.PlayClipAtPoint(needMoreFlameClip, other.transform.position);
			}
		}
	}

}
