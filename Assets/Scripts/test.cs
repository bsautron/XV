using UnityEngine;
using System.Collections;

public class test : MonoBehaviour, IClickable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void rightClick() {
		Debug.Log("right click!");
	}

	public void leftClick() {
		Debug.Log("left click!");
	}
}
