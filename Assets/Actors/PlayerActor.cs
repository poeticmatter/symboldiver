using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveAction))]
public class PlayerActor : Actor {

	public override Action GetAction()
	{
		if (Input.GetKeyDown(KeyCode.W)) {
			return GetMoveAction(IntVector2.UP);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			return GetMoveAction(IntVector2.LEFT);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			return GetMoveAction(IntVector2.DOWN);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			return GetMoveAction(IntVector2.RIGHT);
		}
		return null;
	}




}
