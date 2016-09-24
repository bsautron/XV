﻿using UnityEngine;
using System.Collections;
using System.Threading;

public class Explosing : ABehavior {

	public ParticleSystem		explosion;
	private ParticleSystem		_currentPS;
	
	public string shortName = "Explosing";
	public string description = "Explose a dispositif";

	public void Update () {
		if (this._currentPS && !this._currentPS.IsAlive ()) {
			Destroy (this._currentPS.gameObject);
			this.Stop ();
		}
	}
	
	public override IEnumerator CoBehavior() {
		this._currentPS = Instantiate (this.explosion);
		yield return true;
	}
}
