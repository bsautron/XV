using UnityEngine;
using System.Collections;

public class StatesManager : MonoBehaviour {

	static public StatesManager	instance;

	public enum EBehavior {STANDBY, RUNNING};

	public void Awake() {
		if (!StatesManager.instance)
			StatesManager.instance = this;
	}
}
