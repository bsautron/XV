using UnityEngine;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/**
 * All information inside this class will be save.
 * 
 * Default properties will be save by default, like displayName or position of the gameObject
 * You can add custom information to save if you add the filed name in the inspector.
 * Only filed in the inspector can be set.
 * You can use the method `UpdateField` to assign you field.
 * The value must not to be a GameObject.
 * 
 * get field return a copy of the dictionary
 */

[Serializable]
public class SVector3 {
	public double	x;
	public double	y;
	public double	z;

	public SVector3() {
		this.x = 0;
		this.y = 0;
		this.z = 0;
	}
	public SVector3(Vector3 vector) {
		this.x = vector.x;
		this.y = vector.y;
		this.z = vector.z;
	}
}

[Serializable]
public class SQaternion {
	public double	x;
	public double	y;
	public double	z;
	public double	w;

	public SQaternion() {
		this.x = 0;
		this.y = 0;
		this.z = 0;
		this.w = 0;
	}
	public SQaternion(Quaternion quaternion) {
		this.x = quaternion.x;
		this.y = quaternion.y;
		this.z = quaternion.z;
		this.w = quaternion.w;
	}
}


[Serializable]
public class Fields: Dictionary<string, object>, ISerializable {
	public Fields() : base() { }
	public Fields(Dictionary<string, object> dic) : base(dic) { }

	protected Fields(SerializationInfo info, StreamingContext context) {}

}

[ExecuteInEditMode]
public class Informations : MonoBehaviour {
	[SerializeField] private string _displayName;
	[SerializeField] private string _description;
	[SerializeField] private bool _isInstanciable;
	private System.DateTime	_createdOn;
	private System.DateTime	_updatedOn;

	private Fields _fields = new Fields();

	public Fields fields {
		get { return this._fields; }
	}

	public string[] customFields;
	private List<string> _defaultFields = new List<string>();

	public void Awake() {
		this._defaultFields.Add ("displayName");
		this._defaultFields.Add ("description");
		this._defaultFields.Add ("position");
		this._defaultFields.Add ("rotation");
		this._defaultFields.Add ("isInstiable");

		if (this._displayName == null)
			this._displayName = this.gameObject.name;
		this._createdOn = System.DateTime.Now;
		this._updatedOn = System.DateTime.Now;

		this._fields.Add ("isInstiable", true);
		this._fields.Add("displayName", this._displayName);
		this._fields.Add("description", this._description);
		this._fields.Add("createdOn", this._createdOn);
		this._fields.Add("updatedOn", this._updatedOn);
		this._fields.Add("position", new SVector3(this.transform.position));
		this._fields.Add("rotation", new SQaternion(this.transform.rotation));
//		this._fields.Add("position", this.transform.position);
//		this._fields.Add("rotation", this.transform.rotation);
	}

	public void UpdateField(string fieldName, object value) {

		if (value is MonoBehaviour)
			throw new Exception("You can't save a GameObject");
		if (!this.customFields.Contains (fieldName) && !this._defaultFields.Contains(fieldName))
			Debug.LogError("Field '" + fieldName + "' is not available");
		else {
			if (this._fields.ContainsKey(fieldName))
				this._fields[fieldName] = value;
			else
				this._fields.Add(fieldName, value);

			if (fieldName == "displayName")
				this._displayName = value as string;
			else if (fieldName == "description")
				this._description = value as string;

			this._updatedOn = System.DateTime.Now;
			this._fields["updatedOn"] = this._updatedOn;
			Debug.Log("Field '" + fieldName + "' has been changed");
		}
	}

	public object GetField(string fieldName) {
		return this._fields [fieldName];
	}

}
