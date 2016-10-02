using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterWalk : ABehavior {
	
	private Character 		character;

	public void Start() {
		character = GetComponent<Character> ();
	}

	public void Update () {

	}

	private void MoveTo () {
		this.character.agent.destination = this.character.GetPositionTarget ();
		if (!this.character.agent.pathPending) {
			if (this.character.agent.remainingDistance <= this.character.agent.stoppingDistance) {
				if (!this.character.agent.hasPath || this.character.agent.velocity.sqrMagnitude == 0f) {
					//stop event here
				}
			}
		}
	}

	public override IEnumerator CoBehavior() {
		//start event here
		this.MoveTo ();
		yield return true;
	}

	public override bool IsAvailable() {
		return true;
	}
}
