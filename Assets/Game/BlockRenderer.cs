using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRenderer : MonoBehaviour
{
    public Sprite blockedSprite;
    public Sprite clearedSprite;
    public Sprite[] symbolSprites;
    public SpriteRenderer blockRenderer;
    public SpriteRenderer symbolRenderer;
    public IntVector2 position;

    void Update()
    {

        UpdateState();
        UpdateSymbol();

    }

    private void UpdateSymbol()
	{
        symbolRenderer.sprite = symbolSprites[BoardManager.instance.GetPositionSymbol(position)];
    }
    private void UpdateState()
	{

        bool isBlocked = GameManager.instance.symbol != BoardManager.instance.GetPositionSymbol(position);
        blockRenderer.sprite = isBlocked ? blockedSprite : clearedSprite;

    }
}
