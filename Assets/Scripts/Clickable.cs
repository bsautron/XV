using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

	// Il faut mettre ce script sur un objet, qu'il ait un collider
	// et aussi que le script de l'objet hérite de l'interface IClickable
	// qu'il implémente les deux méthodes leftClick() et rightClick() (ne pas oublier de les mettre public)
	// pour que celui-ci soit cliquable et qu'il fasse les instructions données dans ces deux fonctions

	IClickable clickable;

	// Use this for initialization
	void Start () {
		clickable = (IClickable)gameObject.GetComponent(typeof(IClickable));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)) {
			clickable.leftClick();
		}

		if (Input.GetMouseButtonDown (1)) {
			clickable.rightClick ();
		}
	}
}
