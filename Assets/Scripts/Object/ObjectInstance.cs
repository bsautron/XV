using UnityEngine;
using System.Collections;

public class ObjectInstance : MonoBehaviour {

	private object obj;

	void Awake () {
		InstantiateObject ();
		Debug.Log ("coucou");
	}

	private void InstantiateObject () {
		switch (gameObject.name) {
			case "Box":
				obj = (Box)new Box(this.gameObject);
			break;
		}
	}
}