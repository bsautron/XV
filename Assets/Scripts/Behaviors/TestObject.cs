using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {

	private IBehavior[] _behaviors;

	public void Start() {
		this._behaviors = this.gameObject.GetComponents<IBehavior> ();
	}

	public void Update() {
		if (Input.anyKeyDown) {
			this._behaviors[0].Play ();
		}
	}
}
