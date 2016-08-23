using UnityEngine;
using System.Collections;

public class BehaviorManager : MonoBehaviour {
	public ABehavior[]	listBehavior;

	public void Start() {
		foreach (ABehavior behavior in this.listBehavior) {
			ABehavior b = Instantiate (behavior) as ABehavior;

			b.transform.parent = this.transform;
		}
	}
}
