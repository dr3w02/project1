using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class SkullSmash : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] private GameManagerSkull gameManagerSkull;

    [Header("Graphics")] // this is grabbing all the spites(images)

    [SerializeField] private Sprite skullCracked;


    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    public enum SkullType { skullCrack };
    private SkullType skullType;
    private bool hittable = true;
    private int clickIndex = 0;

  



    public void SetIndex(int index)
    {
        clickIndex = index;
    }






    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        boxCollider2D = GetComponent<BoxCollider2D>();

    }


    public void HitSkull(int playerSkull)
    {
        if (hittable)
        {
            switch (skullType)
            {
                case SkullType.skullCrack:
                    spriteRenderer.sprite = skullCracked;
                    gameManagerSkull.AddScore(clickIndex, playerSkull);
                    //stop the animation of the normal mole as its been hit and now dead
                    StopAllCoroutines();


                    break;


            }

        }
    }

}    