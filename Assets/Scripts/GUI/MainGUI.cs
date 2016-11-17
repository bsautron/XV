using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGUI : MonoBehaviour {

	private	Canvas			_mainCanvas;
//	private	CanvasGroup		_buttonPanel;
//	private	CanvasGroup		_editorPanel;

	// Speed
	private Image 			_stateSpeedImage;
	private Sprite 			_speedPauseImage;
	private	Sprite 			_speedPlayImage;
	private	Sprite 			_speedX2Image;

	private EditorObject	_editorObject;
	private bool 			_isOpenEditorObject = false;


	// Use this for initialization
	void Awake () {
		this._mainCanvas = this.GetComponent<Canvas> ();
//		this._buttonPanel = GameObject.Find ("ButtonPanel").GetComponent<CanvasGroup> ();
//		this._editorPanel = GameObject.Find ("EditorPanel").GetComponent<CanvasGroup> ();

		// Speed
		this._stateSpeedImage = GameObject.Find("StateSpeedImage").GetComponent<Image>();
		this._speedPauseImage = Resources.Load<Sprite> ("GUI/pause");
		this._speedPlayImage = Resources.Load<Sprite> ("GUI/play");
		this._speedX2Image = Resources.Load<Sprite> ("GUI/x2");

		this._editorObject = GameObject.Find ("EditorObjectPanel").GetComponent<EditorObject> ();
	}

	void Update () {
//		if (this._editorPanel.alpha == 1 && !this._isOpenEditorObject && Input.GetMouseButtonDown(0)) {
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			RaycastHit hit;
//
//			if (Physics.Raycast (ray, out hit, 1000)) {
//				EditObject (hit.transform.gameObject);
//			}
//		}

		// Test
		if (Input.GetKeyDown (KeyCode.Space)) {
//			this._buttonPanel.alpha = 1;
			GameManager.instance.state = StatesManager.EGame.PLAY;
			this._stateSpeedImage.sprite = this._speedPlayImage;
//			this._editorPanel.alpha = 0;
//			this._editorPanel.blocksRaycasts = false;
		}
	}

	public void EditObject (GameObject go) {
		AObject aObj;

		GameManager.instance.state = StatesManager.EGame.PAUSE;
		this._stateSpeedImage.sprite = this._speedPauseImage;

		if (aObj = go.GetComponent<AObject> ()) {
			if (aObj.editeable) {
				this._editorObject.Init (aObj);
				this._isOpenEditorObject = true;
				this._editorObject.Open ();
			}
		}
	}

//	public void OpenEditor () {
//		this._buttonPanel.alpha = 0;
//		this._editorPanel.alpha = 1;
//		this._isOpenEditorObject = false;
//		GameManager.instance.state = StatesManager.EGame.PAUSE;
//		this._stateSpeedImage.sprite = this._speedPauseImage;
//	}

	public void OpenSettings () {
		// Open Settings
		Debug.Log("Settings");
//		this._buttonPanel.alpha = 0;
//		this._buttonPanel.blocksRaycasts = false;
	}
}
