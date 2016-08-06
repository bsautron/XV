using UnityEngine;
using System.Collections;

public interface IBehavior<T> {
	void Play();
	void Stop();
	T GetState();
	IEnumerator CoBehavior();
}
