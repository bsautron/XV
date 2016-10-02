/// <summary>
/// Class Character implement simple character behaviors
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour, ICharacter {

	public  int				levelOfCharacter;
	protected Vector3 		_poitionTarget;
	public NavMeshAgent		agent;
	
	//MonoBehaviour
	void Start () {
		this.agent = GetComponent<NavMeshAgent> ();
	}

	//setter getter
	public Vector3 GetPositionTarget () {
		return (_poitionTarget);
	}

	public void SetPositionTarget (Vector3 targetPosition) {
		this._poitionTarget = targetPosition;
	}

 }
