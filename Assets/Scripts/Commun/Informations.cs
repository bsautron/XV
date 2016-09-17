using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/**
 * All information inside this class will be save.
 */

[ExecuteInEditMode]
[System.Serializable]
public class Informations : MonoBehaviour {
	[SerializeField] private string _shortName;
	[SerializeField] private string _description;
	private System.DateTime	_createdOn;
	private System.DateTime	_updatedOn;

	private GenericDictionary _fields = new GenericDictionary();

//	public string[] customsInformations;
	public string[] availableInformations;

	public void Start() {
		this._shortName = this.gameObject.name;
		this._createdOn = System.DateTime.Now;
		this._updatedOn = System.DateTime.Now;

		this._fields.Add<string> ("shortName", this._shortName);
		this._fields.Add<string> ("description", this._description);
		this._fields.AddInterger ("age", 23);

		Debug.Log (this._fields.GetValue<string> ("description"));
	}

	public void UpdateField<T>(string fieldName, T value) where T : class {
		this._updatedOn = System.DateTime.Now;
		if (this.availableInformations.Contains (fieldName)) {
			Debug.LogError ("Field '" + fieldName + "' is GOOD");
			this._fields.Update<T> (fieldName, value);
		} else
			Debug.LogError ("Field '" + fieldName + "' is not available");
	}
}
