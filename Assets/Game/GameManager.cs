using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static int SYMBOL_COUNT;
	public static GameManager instance = null;
	public int level = 0;
	public int symbol = 0;

	void Awake()
	{
		if (instance == null) instance = this;
		else Debug.LogError("More than one GameManager");

	}
}
