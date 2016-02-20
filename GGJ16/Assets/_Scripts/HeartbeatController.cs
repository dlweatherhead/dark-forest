using UnityEngine;
using System.Collections;

public class HeartbeatController : MonoBehaviour {

	public AudioClip slowHeartBeat;
	public AudioClip midHeartBeat;
	public AudioClip fastHeartBeat;

	public float fastDistance;
	public float midDistance;

	public bool slowPlaying = true;
	public bool midPlaying = false;
	public bool fastPlaying = false;

	public float distanceToClosest;

	private float startingVolume;

	private AudioSource audioSource;
	private GameObject[] enemies;

	void Awake() {
		audioSource = gameObject.GetComponent<AudioSource>();

		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		startingVolume = audioSource.volume;
	}

	void FixedUpdate() {
		distanceToClosest = 9999f; // Very Large Number

		foreach(GameObject enemy in enemies) {
			// Determine the closest enemy
				
			float enemyDistance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
	
			if(enemyDistance < distanceToClosest)
				distanceToClosest = enemyDistance;
		}

		if(distanceToClosest < fastDistance) {

			float newVolume = startingVolume + (1f - startingVolume) * (1f - distanceToClosest / fastDistance);
			audioSource.volume = newVolume;

			if(!fastPlaying) {
				audioSource.clip = fastHeartBeat;
				audioSource.Play();
				fastPlaying = true;
				midPlaying = false;
				slowPlaying = false;
			}
			return;
		}

		if(distanceToClosest < midDistance) {

			if(!midPlaying){
				audioSource.clip = midHeartBeat;
				audioSource.volume = startingVolume;
				audioSource.Play();
				midPlaying = true;
				fastPlaying = false;
				slowPlaying = false;
			}
			return;
		}

		if(!slowPlaying) {
			audioSource.clip = slowHeartBeat;
			audioSource.volume = startingVolume;
			audioSource.Play();
			slowPlaying = true;
			midPlaying = false;
			fastPlaying = false;
		}
	}
}
