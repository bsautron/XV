using UnityEngine;
using System.Collections;

public class fake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.state != StatesManager.EGame.PAUSE) {
			this.transform.Rotate (new Vector3 (0, Time.deltaTime * 100, 0));
		}
	}
}
