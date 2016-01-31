using UnityEngine;
using System.Collections;

public class CameraSwitchOnDeath : MonoBehaviour {

	public GameObject secondCamera;

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Enemy")) {
			secondCamera.transform.parent = null;
			secondCamera.SetActive(true);
		}
	}
}
