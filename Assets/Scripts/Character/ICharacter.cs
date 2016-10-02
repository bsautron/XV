using UnityEngine;
using System.Collections;

/// <summary>
/// Implement behavior for all standard players
/// </summary>


public interface ICharacter {

	//common method
//	void SetOrder(string order, Vector3 position, int levelOrder);

	//setter getter
	Vector3 GetPositionTarget ();
	void SetPositionTarget (Vector3 targetPosition);

}
