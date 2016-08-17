using UnityEngine;
using System.Collections;
using System.Threading;

public class Booting : ABehavior {

	public float timeBooting = 2f;
	public float detaTimeLog = 0.2f;

	public void Awake() {
		this._shortName = "Booting";
		this._description = "This is the starting process for a machine";
		this._coBehavior = this.CoBehavior ();
		this._state = StatesManager.EBehavior.STANDBY;
	}
	
	public override IEnumerator CoBehavior() {
		Debug.Log ("Start booting");

		for (float i = 0f; i < timeBooting ; i += detaTimeLog) {
			Debug.Log ("Loading: " + ((i * 100) / timeBooting)  + "%");
			yield return new WaitForSeconds(10);
		}

		Debug.Log ("Loading: 100%");
		Debug.Log ("Booted");
		this.Stop();
		yield return true;
	}
}

// On va plutot attaher un behavior comme script dans l'inspector
