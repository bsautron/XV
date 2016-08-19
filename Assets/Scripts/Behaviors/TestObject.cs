using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {

	private IBehavior[] _behaviors;

	public void Start() {
		this._behaviors = this.gameObject.GetComponents<IBehavior> ();
	}

	public void Update() {
		if (Input.anyKeyDown) {
			this._behaviors[Random.Range(0, this._behaviors.Length)].Play ();
		}
	}
}
