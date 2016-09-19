using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behaviors : MonoBehaviour {

	public ABehavior[]	listBehavior;

	private Dictionary<string, ABehavior>	_dicBehavior = new Dictionary<string, ABehavior>();
	public Dictionary<string, ABehavior> dic { get { return this._dicBehavior; } }

	public void Start() {
		this._InstanciateBahaviors (this.listBehavior);
	}

	private void _InstanciateBahaviors(ABehavior[] listBehavior) {
		foreach (ABehavior behavior in listBehavior) {
			ABehavior b = Instantiate (behavior) as ABehavior;

			this._MapToDictionary (b);
			this._AssignParent (b);
		}
	}

	private void _MapToDictionary(ABehavior behavior) {
		this._dicBehavior.Add (behavior.gameObject.name, behavior);
	}

	private void _AssignParent(ABehavior behavior) {
		behavior.transform.parent = this.transform;
	}
}
