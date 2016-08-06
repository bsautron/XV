using UnityEngine;
using System.Collections;

public class Box : AObject {

	public Box () {
		this._name = "Carton";
		this._description = "Description carton";
		this._weight = 10.0f;
		this._color = gameObject.GetComponent<Material> ().color;
		this.SetTransformObject ();
	}

	public Box (string name, string description, float Weight, Color color) {
		this._name = name;
		this._description = description;
		this._weight = weight;
		this._color = color;
		this.SetTransformObject ();
	}

	private void SetTransformObject () {
		this._positionX = gameObject.transform.position.x;
		this._positionY = gameObject.transform.position.y;
		this._positionZ = gameObject.transform.position.z;

		this._scaleX = gameObject.transform.localScale.x;
		this._scaleY = gameObject.transform.localScale.y;
		this._scaleZ = gameObject.transform.localScale.z;

		this._rotationX = gameObject.transform.rotation.x;
		this._rotationY = gameObject.transform.rotation.y;
		this._rotationZ = gameObject.transform.rotation.z;
	}
}
