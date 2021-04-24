using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DoNothingAction))]
[RequireComponent(typeof(BoardPosition))]
public abstract class Actor : MonoBehaviour {

	private BoardPosition boardPosition = null;
	public BoardPosition BoardPosition
	{
		get {
			if (boardPosition == null)
			{
				boardPosition = GetComponent<BoardPosition>();
			}
			return boardPosition;
		}
	}

	void Start () {
		GameLoop.instance.RegisterActor(this);
	}

	abstract public Action GetAction();

	public void Unregister()
	{
		GameLoop.instance.UnregisterActor(this);
	}
	public Action GetMoveAction(IntVector2 direction)
	{
		MoveAction action = GetComponent<MoveAction>();
		action.direction = direction;
		return action;
	}

}
