using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameManager	gm;

	public void Awake() {
		if (!GameManager.gm)
			GameManager.gm = this;
	}
}
