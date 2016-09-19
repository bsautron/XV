using UnityEngine;
using System.Collections;

/*
 * IBehavior
 * To define a specific behavior
 * You can play or stop the behavior
 * 
 * IEnumerator CoBehavior() is a coroutine, that is THE behavior
 */

public interface IBehavior {
	void Play();
	void Stop();
	bool IsEnableToPlay();
	bool IsEnableToStop();
	bool IsAvailable();
	IEnumerator CoBehavior();
}
