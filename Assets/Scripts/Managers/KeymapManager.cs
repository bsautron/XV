using UnityEngine;
using System.Collections;

public class KeymapManager : Singleton<KeymapManager> {

	public KeyCode	nextCamera = KeyCode.Plus;
	public KeyCode	prevCamera = KeyCode.Minus;
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.state != StatesManager.EGame.PAUSE) {
			if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(this.nextCamera)) {
				// Next camera;
			}
			if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(this.prevCamera)) {
				// Prev Camera;
			}
		}
	}
}
