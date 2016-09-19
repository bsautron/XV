using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/**
 * All information inside this class will be save.
 */

[ExecuteInEditMode]
[System.Serializable]
public class Informations : MonoBehaviour {
	[SerializeField] private string _displayName;
	[SerializeField] private string _description;
	private System.DateTime	_createdOn;
	private System.DateTime	_updatedOn;

	private Dictionary<string, object> _fields = new Dictionary<string, object>();

	public string[] customFields;

	public void Start() {
		this._displayName = this.gameObject.name;
		this._createdOn = System.DateTime.Now;
		this._updatedOn = System.DateTime.Now;

		this._fields.Add("displayName", this._displayName);
		this._fields.Add("description", this._description);
		this._fields.Add("createdOn", this._createdOn);
		this._fields.Add("updatedOn", this._updatedOn);
		this._fields.Add("position", this.transform.position);
		this._fields.Add("rotation", this.transform.rotation);
	}

	public void UpdateField(string fieldName, object value) {

		if (value is MonoBehaviour)
			throw new Exception("You can't save a GameObject");
		if (!this.customFields.Contains (fieldName))
			Debug.LogError("Field '" + fieldName + "' is not available");
		else {
			if (this._fields.ContainsKey(fieldName))
				this._fields["updatedOn"] = this._updatedOn;
			else
				this._fields.Add("updatedOn", this._updatedOn);

			this._updatedOn = System.DateTime.Now;
			this._fields[fieldName] = value;
			Debug.Log("Field '" + fieldName + "' has been changed");
		}

	}
}
