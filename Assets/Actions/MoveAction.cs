using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DoNothingAction))]
public class MoveAction : Action {

	public IntVector2 direction;

	override public ActionResult Perform()
	{
		if (!CanPerform())
		{
			return ActionResult.FAILURE(GetComponent<DoNothingAction>());
		}
		state = ActionState.EXECUTING;
		return ActionResult.SUCCESS;

	}

	void Update ()
	{
		if (state == ActionState.EXECUTING)
		{
			BoardPosition boardPosition = GetComponent<BoardPosition>();
			boardPosition.MoveDirection(direction);
			//Temporary movement.
			transform.Translate(new Vector2(direction.X, direction.Y));
			state = ActionState.FINISHED;
			Debug.Log(name + " performed move action.");
		}
	}

	private bool CanPerform()
	{
		return GetComponent<BoardPosition>().CanMoveDirection(direction);
	}
}
