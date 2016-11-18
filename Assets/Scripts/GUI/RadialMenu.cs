using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RadialMenu : MonoBehaviour {

	public RadialButton buttonPrefab;

	[HideInInspector]
	public RadialButton selected;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	
	}

	public delegate void fct();

	private void InstantiateButton(int i, int lenght, string name, fct fctOnclick) {
		RadialButton newButton = Instantiate (buttonPrefab) as RadialButton;
		newButton.transform.SetParent (transform, false);
		float theta = (2 * Mathf.PI / lenght) * i;
		float xPos = Mathf.Sin (theta);
		float yPos = Mathf.Cos (theta);

		newButton.transform.localPosition = new Vector3 (xPos, yPos, 0f) * 100f;
		Button bt = newButton.GetComponent<Button> ();
		bt.onClick.AddListener (() => {fctOnclick();});
		bt.GetComponentInChildren<Text> ().text = name;
	}

	public void SpawnButtons(AObject obj) {
		Behaviors behaviors = obj.GetComponent<Behaviors> ();
		int i = 1;

		InstantiateButton (0, behaviors.dic.Count + 1, "Edit", delegate {GUIManager.instance.GetComponent<MainGUI>().EditObject(obj.gameObject);obj.GetComponent<OpenRadialMenu>().Desactivate();});
		foreach (KeyValuePair<string, ABehavior> elem in behaviors.dic) {
			InstantiateButton (i, behaviors.dic.Count + 1, elem.Key, delegate{elem.Value.Play();obj.GetComponent<OpenRadialMenu>().Desactivate();});
			++i;
		}
	}
}
