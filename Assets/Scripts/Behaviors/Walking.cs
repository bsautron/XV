using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walking : ABehavior<bool> {
	
	private Character 		_character;
	private Queue<Vector3> 	_targetPositionTab = new Queue<Vector3>();
	private Vector3			_targetPosition;
	private bool			_onDeplacement = false;

	public override void Start() {
		base.Start ();
		this._character = this._parent.GetComponent<Character> ();
	}

	public void Update() {

	}
	
	public override IEnumerator CoBehavior() {
		NavMeshAgent charaterAgent = this._character.agent;
		this._targetPosition = this._targetPositionTab.Peek ();
		this._character.agent.SetDestination(this._targetPosition);

		Debug.Log (this._targetPosition);
//		this._onDeplacement = true;


		yield return new WaitForEndOfFrame();

//		charaterAgent.Resume ();
		Debug.Log (charaterAgent.hasPath);
		Debug.Log(charaterAgent.remainingDistance + " > " + charaterAgent.stoppingDistance);

		while (charaterAgent.remainingDistance > charaterAgent.stoppingDistance) {
			yield return true;
		}
//		this._onDeplacement = false;
//		charaterAgent.Stop ();
		this._targetPositionTab.Dequeue ();
		this.Stop ();
		Debug.Log (charaterAgent.remainingDistance);
		Debug.Log (charaterAgent.hasPath);
		
		yield return new WaitForSeconds(2f);
	}

	public override bool IsAvailable() {
		return true;
	}

	public void SetTargetPosition(Vector3 pos) {
		this._targetPositionTab.Enqueue(pos);
	}

}
