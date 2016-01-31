using UnityEngine;
using System.Collections;

public class NephalemCollector : MonoBehaviour {

	private int nephalemFlamesCollected = 0;

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("NephalemFlame")) {
			nephalemFlamesCollected++;
		}
	}

	public int flamesCollected() {
		return nephalemFlamesCollected;
	}
}
