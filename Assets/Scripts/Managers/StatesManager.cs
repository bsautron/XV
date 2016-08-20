using UnityEngine;
using System.Collections;

public class StatesManager : MonoBehaviour {

	static public StatesManager	instance;

	/* List all different State available Here */
	public enum EBehavior {STANDBY, RUNNING};

	public void Awake() {
		if (!StatesManager.instance)
			StatesManager.instance = this;
	}
}
