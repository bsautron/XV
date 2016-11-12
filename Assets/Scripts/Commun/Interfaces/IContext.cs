using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IContext<T> {
	void AddContext(T value);
	T GetContext();
}
