using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSymbolRenderer : MonoBehaviour
{
    public Sprite[] symbolSprites;
    public SpriteRenderer symbolRenderer;

    void Update()
    {
        UpdateSymbol();
    }

    private void UpdateSymbol()
    {
        symbolRenderer.sprite = symbolSprites[GameManager.instance.symbol];
    }
}
