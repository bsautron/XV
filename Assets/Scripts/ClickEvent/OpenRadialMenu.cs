using UnityEngine;
using System.Collections;

public class OpenRadialMenu : AClickable {

	public RadialMenu radialMenuPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnMouseOver(){
		if (_rightCLick == false && Input.GetMouseButtonDown(0)) {
			ClickManager.instance.ManageEvent (this);
		}

		if (_rightCLick == true && Input.GetMouseButtonDown (1)) {
			ClickManager.instance.ManageEvent (this);
		}
	}

	public override void Activate(){
		Debug.Log("Popup Info activate");
		SpawnMenu ();
		_active = true;
	}

	public override void Desactivate(){
		Debug.Log("Popup Info desactivate");
		_active = false;
	}

	public void SpawnMenu() {
		RadialMenu newMenu = Instantiate (radialMenuPrefab) as RadialMenu;
		newMenu.transform.SetParent (GUIManager.instance.gameObject.transform, false); //TO DO add transform of maincanvas
//		newMenu.transform.position =; // TO DO center postion of object
	}
}
