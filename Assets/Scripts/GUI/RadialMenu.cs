using UnityEngine;
using System.Collections;

public class RadialMenu : MonoBehaviour {

	public RadialButton buttonPrefab;

	[HideInInspector]
	public RadialButton selected;

	// Use this for initialization
	void Start () {
		RadialButton newButton = Instantiate (buttonPrefab) as RadialButton;
		newButton.transform.SetParent (transform, false);
		newButton.transform.localPosition = new Vector3 (0f, 100f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
