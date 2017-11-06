using UnityEngine;
using System.Collections;

public class NephalemCollector : MonoBehaviour {

	private int nephalemFlamesCollected;

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("NephalemFlame")) {
			nephalemFlamesCollected++;
		}
	}

	public int flamesCollected() {
		return nephalemFlamesCollected;
	}
}
