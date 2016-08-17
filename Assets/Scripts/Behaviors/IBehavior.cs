using UnityEngine;
using System.Collections;

/*
 * IBehavior
 * To define a behavior
 * You can play or stop the behavior
 * 
 * IEnumerator CoBehavior() is a coroutine, that is THE behavior
 */

public interface IBehavior : IState<StatesManager.EBehavior>, IDetailable {
	void Play();
	void Stop();
	IEnumerator CoBehavior();
}
