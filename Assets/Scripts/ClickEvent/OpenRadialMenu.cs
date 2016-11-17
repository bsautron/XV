using UnityEngine;
using System.Collections;

public class OpenRadialMenu : AClickable {

	public RadialMenu radialMenuPrefab;

	private	AObject	_object;
	private RadialMenu newMenu;

	// Use this for initialization
	void Start () {
		_object = gameObject.GetComponent<AObject> ();
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
		this.SpawnMenu ();
		this._active = true;
	}

	public override void Desactivate(){
		Debug.Log("Popup Info desactivate");
		Destroy (newMenu.gameObject);
		ClickManager.instance.resetCurrentEvent ();
		this._active = false;
	}

	public void SpawnMenu() {
		newMenu = Instantiate (radialMenuPrefab) as RadialMenu;
		newMenu.transform.SetParent (GUIManager.instance.gameObject.transform, false); //TO DO add transform of maincanvas
//		newMenu.transform.position = Input.mousePosition; // TO DO center position of object
		newMenu.SpawnButtons(_object);

	}
}
