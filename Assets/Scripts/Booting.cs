using UnityEngine;
using System.Collections;

public class Booting : ABehavior {

	public float timeBooting = 2f;
	public float detaTimeLog = 0.2f;

	public void Start() {
		this.Play ();
	}
	
	public override IEnumerator CoBehavior(AObject aObject) {
		Debug.Log ("Start booting");

		for (float i = 0f; i < timeBooting ; i += detaTimeLog) {
			Debug.Log ("Loading: " + ((i * 100) / timeBooting)  + "%");
			yield return new WaitForSeconds(detaTimeLog);
		}

		Debug.Log ("Loading: 100%");
		Debug.Log ("Booted");
		yield return true;
		this.Stop ();
	}
}
