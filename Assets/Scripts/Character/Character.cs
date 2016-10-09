/// <summary>
/// Class Character implement simple character behaviors
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour, ICharacter {

	private StackInstruction _instructions = new StackInstruction();
	public bool 			_isAttached { get; private set; }

	public NavMeshAgent		agent;
	public  int				levelOfCharacter;
	public StackInstruction stackInstructions { get { return this._instructions; } }

	protected Vector3 		_poitionTarget;

	//MonoBehaviour
	void Start () {
		this.agent = GetComponent<NavMeshAgent> ();
		this._isAttached = false;
	}

	//setter getter
	public Vector3 GetPositionTarget () {
		return (this._poitionTarget);
	}

	public void SetPositionTarget (Vector3 targetPosition) {
		this._poitionTarget = targetPosition;
	}

 }