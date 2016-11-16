using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[ExecuteInEditMode]
public class InfosPopup : AClickable {

	[SerializeField] private GameObject _panelPrefab;
	[SerializeField] private GameObject _buttonPrefab;
	[SerializeField] private GameObject _canvas;

	private RectTransform _panelRT;
	private	GameObject _contentScrollView;
	private	AObject	_object;
	private	Text[] _tabText;
	private GameObject _panelInstance;

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
		_panelInstance = Instantiate(_panelPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f), Quaternion.identity) as GameObject;
		_panelInstance.SetActive (true);
		_panelInstance.transform.SetParent (_canvas.transform, false);
		_panelRT = _panelInstance.gameObject.GetComponent<RectTransform>();
		_contentScrollView = _panelInstance.gameObject.GetComponentInChildren<ScrollRect> ().gameObject.GetComponentInChildren<VerticalLayoutGroup>().gameObject;
		_object = gameObject.GetComponent<AObject> ();
		_tabText = _panelInstance.GetComponentsInChildren<Text> ();

		for (int i = 0; i < _tabText.Length; i++) {
			Informations infos = _object.GetComponent<Informations>();
			if (_tabText[i].name == "ObjectName")
				_tabText [i].text = infos.GetField("displayName") as string;
			else
				_tabText [i].text = infos.GetField("description") as string;
		}

		foreach (KeyValuePair<string, ABehavior> elem in _object.GetComponent<Behaviors>().dic) {
			GameObject instanceBt = Instantiate(_buttonPrefab, new Vector3(_contentScrollView.transform.position.x, _contentScrollView.transform.position.y, 0.0f), Quaternion.identity) as GameObject;
			instanceBt.transform.SetParent(_contentScrollView.transform, false);

			Button bt = instanceBt.GetComponent<Button> ();
			bt.onClick.AddListener (elem.Value.Play);
			bt.GetComponentInChildren<Text> ().text = elem.Key;
		}
		Debug.Log("Popup Info activate");
		_active = true;
	}

	public override void Desactivate(){
		GameObject.Destroy (_panelInstance.gameObject);
		Debug.Log("Popup Info desactivate");
		_active = false;
	}

	private void _InstantiatePanel() {
	}
}
