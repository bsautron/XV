using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behaviors : MonoBehaviour {

	[SerializeField] public ABehavior[]	_tabBehavior;

	private Dictionary<string, ABehavior>	_dicBehavior = new Dictionary<string, ABehavior>();
	public Dictionary<string, ABehavior> dic { get { return this._dicBehavior; } }

	public void Awake() {
		foreach (ABehavior behavior in this._tabBehavior) {
			this._MapToDictionary (behavior);
		}
	}

	private void _MapToDictionary(ABehavior behavior) {
		string behaviorName = behavior.GetComponent<Informations> ().name;
		this._dicBehavior.Add (behaviorName, behavior);
	}

	private void _AssignParent(ABehavior behavior) {
		behavior.transform.parent = this.transform;
	}

	// faire un truck qui puisse montrer le nombre d'instance dans la scene et qui puisse limiter le nombre dans le nombre pour le meme objecthiy 

	public ABehavior InvokeBehavior(string behaviorName) {
		ABehavior behavior = Instantiate (this.dic [behaviorName], this.transform.position, Quaternion.identity) as ABehavior;
		this._AssignParent (behavior);
		return behavior;
	}

	public ABehavior InvokeBehavior(string behaviorName, object context) {
		ABehavior behavior = this.InvokeBehavior (behaviorName);
		behavior.context = context;
		return behavior;
	}
}
