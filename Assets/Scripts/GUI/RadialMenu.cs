﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RadialMenu : MonoBehaviour {

	public RadialButton buttonPrefab;

	private Button[] _visiblebButtons;
	private Dictionary<string, ABehavior> _dic;
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

	public delegate void fct();

	private KeyValuePair<string, ABehavior>  _FindNewBehavior(int current, bool prev){
		if (prev) {
			if (current == 0) {
				return (this._dic.ElementAt (this._dic.Count - 1));
			} else
				return (this._dic.ElementAt (current - 1));
		}
		else {
			if (current == this._dic.Count - 1) {
				return (this._dic.ElementAt (0));
			} else {
				return (this._dic.ElementAt(current + 1));
			}
		}
	}

	public void _MoveLeft(){
		int i = 0;

		while (i < this._maxNumberButton - 1) {
			this._visiblebButtons [i + 1].transform.localPosition = this._visiblebButtons [i].transform.localPosition;
		}
		KeyValuePair<string, ABehavior> prev = _FindNewBehavior(0, true);
		this._visiblebButtons [0].GetComponent<Text> ().text = prev.Key;
		this._visiblebButtons [0].onClick.RemoveAllListeners ();
		this._visiblebButtons [0].onClick.AddListener (delegate {
			prev.Value.Play ();
			this._aObj.GetComponent<OpenRadialMenu> ().Desactivate ();
		});
	}

	public void _MoveRight(){
		int i = 0;

		while (i < this._maxNumberButton - 1) {
			this._visiblebButtons [i].transform.localPosition = this._visiblebButtons [i + 1].transform.localPosition;
		}
		KeyValuePair<string, ABehavior> next = _FindNewBehavior(i, false);
		this._visiblebButtons [i].GetComponent<Text> ().text = next.Key;
		this._visiblebButtons [i].onClick.AddListener(delegate {
			next.Value.Play ();
			this._aObj.GetComponent<OpenRadialMenu> ().Desactivate ();
		});
	}

	private void InstantiateButton(int i, int lenght, string name, UnityEngine.Events.UnityAction fctOnclick) {
		RadialButton newButton = Instantiate (buttonPrefab) as RadialButton;
		newButton.transform.SetParent (transform, false);

		if (lenght > this._maxNumberButton)
			lenght = this._maxNumberButton;
		float theta = (2 * Mathf.PI / (lenght + 1)) * i;
		float xPos = Mathf.Sin (theta);
		float yPos = Mathf.Cos (theta);
		newButton.transform.localPosition = new Vector3 (xPos, yPos, 0f) * 100f;

		this._visiblebButtons [i] = Instantiate (newButton.GetComponent<Button> ());
		this._visiblebButtons [i].onClick.AddListener (delegate {
			fctOnclick();
			this._aObj.GetComponent<OpenRadialMenu> ().Desactivate ();
		});
		this._visiblebButtons [i].GetComponentInChildren<Text> ( ).text = name;
	}

	public void SpawnButtons(AObject obj) {
		this._aObj = obj; 
		Behaviors behaviors = obj.GetComponent<Behaviors> ();
		this._dic  = behaviors.dic;
		int i = 1;

		InstantiateButton (0, this._dic.Count, "Edit", delegate {
			GUIManager.instance.GetComponent<MainGUI>().EditObject(obj.gameObject);
		});
		foreach (KeyValuePair<string, ABehavior> elem in this._dic) {
			if (i < this._maxNumberButton) {
				InstantiateButton (i++, this._dic.Count, elem.Key, elem.Value.Play);
			}
		}
	}
}
