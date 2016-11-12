using UnityEngine;
using System.Collections;

public class Explosing : ABehavior {

	public ParticleSystem		explosion;
	private ParticleSystem		_currentPS;
	
	public override IEnumerator CoBehavior() {
		this._currentPS = Instantiate (this.explosion);
		if (this._currentPS) {
			while (this._currentPS.IsAlive ()) {
				yield return true;
			}
			Destroy (this._currentPS.gameObject);
		}
		this._currentPS = Instantiate (this.explosion, this.transform.position, Quaternion.identity) as ParticleSystem;
		this.Stop ();
		yield return true;
	}

	public override bool IsAvailable() {
		return true;
	}
}
