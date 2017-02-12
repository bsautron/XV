using UnityEngine;
using System.Collections;
using System.Collections.Generic;

struct Event {
	public ABehavior behavior;
	public Time worldTime;
}

public class ReplayManager : Singleton<ReplayManager> {
	// Here is the global List replay
//	public List<Event>	sources;

	public void PushEvent(ABehavior behavior) {
		behavior.transform.parent = this.transform;
//		Debug.Log(Time.realtimeSinceStartup);
	}
}
