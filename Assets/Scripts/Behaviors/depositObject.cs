using UnityEngine;
using System.Collections;

public class depositObject : ABehavior {

	private Character 		_character;
	
	public void Start() {
		_character = GetComponent<Character> ();
	}
	
	public void Update () {
		
	}
	
	public override IEnumerator CoBehavior() {
//		if (!_character.checkIfobjectTarget()) {
//			_character._objectTarget.transform.parent = null;
//			_character._objectTarget.transform.position = destPosition;
//			_objectAttached = null;
//		} else {
//			Debug.Log("You don't have an object attach");
//		}
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
