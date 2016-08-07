using UnityEngine;
using System.Collections;

public class Box : AObject {

	private GameObject _parent;

	public Box (GameObject parent) {
		this._parent = parent;
		this._nameParent = this._parent.name;
		this._name = "Carton";
		this._description = "Description carton";
		this._weight = 10.0f;
		this._color = Color.white;
		this.SetTransformObject ();
	}

	public Box (string name, string description, float Weight, Color color) {
		this._name = name;
		this._description = description;
		this._weight = weight;
		this._color = color;
		this.UpdateColor ();
		this.SetTransformObject ();
	}

	private void SetTransformObject () {
		this._positionX = this._parent.transform.position.x;
		this._positionY = this._parent.transform.position.y;
		this._positionZ = this._parent.transform.position.z;

		this._scaleX = this._parent.transform.localScale.x;
		this._scaleY = this._parent.transform.localScale.y;
		this._scaleZ = this._parent.transform.localScale.z;

		this._rotationX = this._parent.transform.rotation.x;
		this._rotationY = this._parent.transform.rotation.y;
		this._rotationZ = this._parent.transform.rotation.z;
	}
}
