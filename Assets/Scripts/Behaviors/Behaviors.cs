using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[System.Serializable]
//public class Behaviors {

//	public ABehavior	booting;
//	public ABehavior	explosing;
//	public ABehavior[]	listBehavior;
//
//	private Dictionary<string, ABehavior>	_dicBehavior = new Dictionary<string, ABehavior>();
//
//	public void Start() {
//		this._InstanciateBahaviors (this.listBehavior);
//	}
//
//	private void _InstanciateBahaviors(ABehavior[] listBehavior) {
//		foreach (ABehavior behavior in listBehavior) {
//			ABehavior b = Instantiate (behavior) as ABehavior;
//
//			this._MapToDictionary (b);
//			this._AssignParent (b);
//		}
//	}
//
//	private void _MapToDictionary(ABehavior behavior) {
//		Detailable behaviorDetails = behavior.transform.GetComponent<Detailable> ();
//		this._dicBehavior.Add (behaviorDetails.shortName, behavior);
//	}
//
//	private void _AssignParent(ABehavior behavior) {
//		behavior.transform.parent = this.transform;
//	}
//}
