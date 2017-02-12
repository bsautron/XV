using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Event {
	public ABehavior behavior;
	public float worldTime;
	public float waitingTimeForNext;
}

public class ReplayManager : Singleton<ReplayManager> {
	// Here is the global List replay
	public List<Event>	sources = new List<Event>();

	public void PushEvent(ABehavior behavior) {
		behavior.transform.parent = this.transform;
		Event newEvent = new Event () {
			behavior = behavior,
			worldTime = Time.realtimeSinceStartup
		};

		this.sources.Add(newEvent);
	}

	public void StartReplay() {
		StartCoroutine (this._coReplay());
	}

	private IEnumerator _coReplay() {
		Debug.Log ("Start Replay!");
		int	i = 0;
		foreach (Event ev in this.sources) {
			ev.behavior.Play ();

			if (i < this.sources.Count - 1) {
				Event nextEvent = this.sources [i + 1];
				Debug.Log ("Le prochaine dans " + (nextEvent.worldTime - ev.worldTime) + " sec");
				i++;
				yield return new WaitForSeconds (nextEvent.worldTime - ev.worldTime);
			} else {
				// Wait for end of last behavior
			}
		}
		Debug.Log ("End Replay!");
	}
}
