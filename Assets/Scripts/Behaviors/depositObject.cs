using UnityEngine;
using System.Collections;

public class depositObject : ABehavior {

	public void Update () {
		
	}
	
	public override IEnumerator CoBehavior() {
		this.transform.parent = null;
		yield return true;
	}

	public override bool IsAvailable() {
		return true;
	}

//	public void DepositObject (Vector3 destPosition) {
//		if (_objectAttached) {
//			_objectAttached.transform.parent = null;
//			_objectAttached.transform.position = destPosition;
//			_objectAttached = null;
//		} else {
//			Debug.Log("You don't have an object attach");
//		}
//	}
}