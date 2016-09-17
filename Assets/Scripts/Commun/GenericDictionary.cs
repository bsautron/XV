using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericDictionary {
	private Dictionary<string, Informations> _dict = new Dictionary<string, object>();
	
	public void Add<T>(string key, T value) where T : class {
		this._dict.Add(key, value);
	}

	public void Update<T>(string key, T value) where T : class {
		if (this.KeyExist (key))
			this._dict [key] = value;
		else
			this.Add<T> (key, value);
	}
	
	public T GetValue<T>(string key) where T : class {
		return this._dict[key] as T;
	}

	public bool	KeyExist(string key) {
		return this._dict.ContainsKey (key);
	}
}
