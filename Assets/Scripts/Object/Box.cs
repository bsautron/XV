using UnityEngine;
using System.Collections;

public class Box : AObject {

	private GameObject _parent;

	void Start () {
		this._name = "Carton";
		this._description = "Description carton";
		this._weight = 10.0f;
		this._color = Color.white;
		this._positionX = this.transform.position.x;
		this._positionY = this.transform.position.y;
		this._positionZ = this.transform.position.z;
		
		this._scaleX = this.transform.localScale.x;
		this._scaleY = this.transform.localScale.y;
		this._scaleZ = this.transform.localScale.z;
		
		this._rotationX = this.transform.rotation.x;
		this._rotationY = this.transform.rotation.y;
		this._rotationZ = this.transform.rotation.z;
	}
}
