using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullClicker : MonoBehaviour
{
    [SerializeField] private Sprite hammerUp;
    [SerializeField] private Sprite hammerDown;

    [Header("GameManager")]
    [SerializeField] private GameManagerSkull gameManagerSkull;
    private SpriteRenderer spriteRenderer;

    public enum HammerSprite { hammerUp,hammerDown};
    private HammerSprite hammerSprite;

    private bool hittable = true;
    private int clickIndex = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetIndex(int index)
    {
        clickIndex = index;
    }
    
    
    public void Clicker(int player)
    {
        if(hittable)
        {
            switch(hammerSprite)
            {
                case HammerSprite.hammerUp:
                spriteRenderer.sprite = hammerDown;
                gameManagerSkull.AddScore(clickIndex, player);

                    break;
            }



        }
    }




}
  





