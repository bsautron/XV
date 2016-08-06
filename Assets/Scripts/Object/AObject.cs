using UnityEngine;
using System.Collections;

public abstract class AObject : MonoBehaviour, IObject {
	
	// POSITION X, Y, Z
	protected	float	_positionX;
	public		float	positionX {
		get { return this._positionX; }
		set { this._positionX = positionX; }
	}
	
	protected	float	_positionY;
	public		float	positionY {
		get { return this._positionY; }
		set { this._positionY = positionY; }
	}
	
	protected	float	_positionZ;
	public		float	positionZ {
		get { return this._positionZ; }
		set { this._positionZ = positionZ; }
	}

	// SCALE X, Y, Z
	protected	float	_scaleX;
	public		float	scaleX {
		get { return this._scaleX; }
		set { this._scaleX = scaleX; }
	}
	
	protected	float	_scaleY;
	public		float	scaleY {
		get { return this._scaleY; }
		set { this._scaleY = scaleY; }
	}

	protected	float	_scaleZ;
	public	float	scaleZ {
		get { return this._scaleZ; }
		set { this._scaleZ = scaleZ; }
	}

	// ROTATION X, Y, Z
	protected	float	_rotationX;
	public		float	rotationX {
		get { return rotationX; }
		set { _rotationX = rotationX; }
	}

	protected	float	_rotationY;
	public		float	rotationY {
		get { return rotationY; }
		set { _rotationY = rotationY; }
	}

	protected	float	_rotationZ;
	public		float	rotationZ {
		get { return rotationZ; }
		set { _rotationZ = rotationZ; }
	}
	
	// OTHER
	protected	float	_weight;
	public		float	weight {
		get { return this._weight; }
		set { this._weight = weight; }
	}

	protected 	bool	_isActive;
	public		bool	isActive {
		get { return this._isActive; }
		set { this._isActive = isActive; }
	}

	protected	string	_name;
	public		string	name {
		get { return this._name; }
		set { this._name = name; }
	}

	protected	string	_description;
	public		string	description {
		get { return this._description; }
		set { this._description = description; }
	}
	
	protected	Color	_color;
	public		Color	color {
		get { return this._color; }
		set { this._color = color; }
	}

	// INTERFACE IObject
	public virtual void UpdateColor () {
		gameObject.GetComponent<Material> ().color = this._color;
		Debug.Log ("Color updated (r, g, b) : (" + this._color.r + ", " + this._color.g + ", " + this._color.b + ")");
	}
}
