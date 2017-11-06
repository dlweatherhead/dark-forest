using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindPlayerLooper : MonoBehaviour {

	public AudioClip[] windArray;
	private AudioSource audioSource;

	private int currentClip;

	void Awake() {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update() {
		if(!audioSource.isPlaying) {
			audioSource.clip = windArray[currentClip];
			audioSource.Play();

			if(currentClip < windArray.Length)
				currentClip++;
			else
				currentClip = 0;
		}
	}
}
