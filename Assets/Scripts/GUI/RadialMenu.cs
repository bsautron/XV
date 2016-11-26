using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RadialMenu : MonoBehaviour {

	public delegate void fct();

	private	struct buttonInfos {
		public fct		fct;
		public string	name;
	}

	public RadialButton buttonPrefab;
	public RadialButton	leftArrowButtonPrefab;
	public RadialButton	rightArrowButtonPrefab;

	private Button[] _visiblebButtons;
	private buttonInfos[] _tabButtonsInfos;
	private AObject _aObj;
	private int _maxNumberButton;

	// Use this for initialization
	void Awake () {
		this._maxNumberButton = 8;
		this._visiblebButtons = new Button[this._maxNumberButton];
	}

	// Update is called once per frame
	void Update () {
	
	}
		
	private buttonInfos  _FindNewBehavior(string name, bool prev){
		int i = -1;

		if (prev) {
			while (++i < this._tabButtonsInfos.Length) {
				if (name == this._tabButtonsInfos[i].name) {
					if (i == 0)
						return this._tabButtonsInfos [this._tabButtonsInfos.Length - 1]; 
					return this._tabButtonsInfos[i - 1];
				}
			}
		}
		else {
			while (++i < this._tabButtonsInfos.Length) {
				if (name == this._tabButtonsInfos[i].name) {
					if (i == this._tabButtonsInfos.Length - 1)
						return this._tabButtonsInfos [0];
					return this._tabButtonsInfos[i + 1];
				}
			}
		}
		return (default(buttonInfos));
	}

	public void _MoveLeft(){
		buttonInfos prev;
		Vector3 tmpPos = this._visiblebButtons[0].transform.localPosition;
		Button tmpBt = this._visiblebButtons [this._visiblebButtons.Length - 1];
		int i = -1;

		while (++i < this._visiblebButtons.Length - 1) {
			this._visiblebButtons [i].transform.localPosition = this._visiblebButtons [i + 1].transform.localPosition;
		}
		this._visiblebButtons[i].transform.localPosition = tmpPos;

		i = this._maxNumberButton;
		while (--i > 0) {
			this._visiblebButtons [i] = this._visiblebButtons [i - 1];
		}
		this._visiblebButtons [0] = tmpBt;
		
		string name = this._visiblebButtons [0].GetComponentInChildren<Text> ().text;
		prev = _FindNewBehavior(name, false);
		this._visiblebButtons [0].GetComponentInChildren<Text> ().text = prev.name;
		this._visiblebButtons [0].onClick.RemoveAllListeners ();
		this._visiblebButtons [0].onClick.AddListener (() => {prev.fct();});
	}

	public void _MoveRight(){
		buttonInfos next;
		Vector3 tmpPos = this._visiblebButtons[this._visiblebButtons.Length - 1].transform.localPosition;
		Button tmpBt = this._visiblebButtons [0];
		int i = this._visiblebButtons.Length;

		while (--i > 0) {
			this._visiblebButtons [i].transform.localPosition = this._visiblebButtons [i - 1].transform.localPosition;
		}
		this._visiblebButtons [0].transform.localPosition = tmpPos;
		
		i = -1;
		while (++i < this._visiblebButtons.Length - 1) {
			this._visiblebButtons [i] = this._visiblebButtons [i + 1];
		}
		this._visiblebButtons [this._visiblebButtons.Length - 1] = tmpBt;
		
		string name = this._visiblebButtons [i].GetComponentInChildren<Text> ().text;
		next = _FindNewBehavior(name, true);
		this._visiblebButtons [i].GetComponentInChildren<Text> ().text = next.name;
		this._visiblebButtons [i].onClick.RemoveAllListeners ();
		this._visiblebButtons [i].onClick.AddListener (() => {next.fct();});
	}

	private void InstantiateButton(int i, int lenght, buttonInfos buttonInfos) {
		RadialButton newButton = Instantiate (this.buttonPrefab) as RadialButton;
		newButton.transform.SetParent (this.transform, false);

		if (lenght > this._maxNumberButton)
			lenght = this._maxNumberButton;
		float theta = (2 * Mathf.PI / (lenght + 1)) * i;
		float xPos = Mathf.Sin (theta);
		float yPos = Mathf.Cos (theta);
		newButton.transform.localPosition = new Vector3 (xPos, yPos, 0f) * 100f;

		this._visiblebButtons [i] = newButton.GetComponent<Button> ();
		this._visiblebButtons [i].GetComponentInChildren<Text> ().text = buttonInfos.name;
		this._visiblebButtons [i].onClick.AddListener (() => {buttonInfos.fct();});
	}

	public void SpawnButtons(AObject obj) {
		this._aObj = obj;
		Behaviors behaviors = obj.GetComponent<Behaviors> ();
		this._tabButtonsInfos  = new buttonInfos[behaviors.dic.Count + 1];
		buttonInfos buttonInfos;
		int i = 1;

		buttonInfos.name = "Edit";
		buttonInfos.fct = delegate {
			GUIManager.instance.GetComponent<MainGUI>().EditObject(obj.gameObject);
			this._aObj.GetComponent<OpenRadialMenu> ().Desactivate ();
		};
		this._tabButtonsInfos[0] = buttonInfos;
		InstantiateButton (0, behaviors.dic.Count, buttonInfos); 
		foreach (KeyValuePair<string, ABehavior> elem in behaviors.dic) {
			KeyValuePair<string, ABehavior> tmp = elem;
			buttonInfos.name = tmp.Key;
			buttonInfos.fct = delegate {
				tmp.Value.Play();
				this._aObj.GetComponent<OpenRadialMenu> ().Desactivate ();
			};
			if (i < this._maxNumberButton) {
				InstantiateButton (i, behaviors.dic.Count, buttonInfos);
			}
			this._tabButtonsInfos[i++] = buttonInfos;
		}
		if (i >= this._maxNumberButton) {
			RadialButton leftArrowButton = Instantiate (this.leftArrowButtonPrefab) as RadialButton;
			leftArrowButton.transform.SetParent (this.transform, false);
			Button bt = leftArrowButton.GetComponent<Button>();
			bt.onClick.AddListener (this._MoveLeft);
			bt.GetComponentInChildren<Text>().text = "";

			RadialButton rightArrowButton = Instantiate (this.rightArrowButtonPrefab) as RadialButton;
			rightArrowButton.transform.SetParent (this.transform, false);
			bt = rightArrowButton.GetComponent<Button>();
			bt.onClick.AddListener (this._MoveRight);
			bt.GetComponentInChildren<Text>().text = "";
		}
	}
}
