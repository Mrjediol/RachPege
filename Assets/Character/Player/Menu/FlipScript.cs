using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipScript : MonoBehaviour
{
    public SpriteRenderer spriteToFlip;
    public Button flipButton;

    public void Start()
    {
        flipButton.onClick.AddListener(FlipSprite);
    }

    public void FlipSprite()
    {
        Debug.Log("girar");
        spriteToFlip.flipY = !spriteToFlip.flipY;
    }
}
