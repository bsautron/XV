using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behaviors : MonoBehaviour {

	[SerializeField] private ABehavior[]	_tabBehavior;

	private Dictionary<string, ABehavior>	_dicBehavior = new Dictionary<string, ABehavior>();
	public Dictionary<string, ABehavior> dic { get { return this._dicBehavior; } }

	public void Start() {
		this._Init (this._tabBehavior);
	}

	private void _Init(ABehavior[] listBehavior) {
		foreach (ABehavior behavior in listBehavior) {
//			ABehavior b = Instantiate (behavior, this.transform.position, Quaternion.identity) as ABehavior;
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

	// faire un truck qui puisse monttrer le nombre d'instance dans la scene et qui puisse limiter le nombre dans le nombre pour le meme object
	public void InvokeBehavior(string behaviorName, object context) {
		ABehavior behavior = Instantiate (this.dic [behaviorName], this.transform.position, Quaternion.identity) as ABehavior;
		behavior.context = context;
		this._AssignParent (behavior);
		behavior.Play ();
	}
}
