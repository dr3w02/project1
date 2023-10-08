using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class SkullSmash : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] private GameManagerSkull gameManagerSkull;
    Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool hittable = true;
    private int skullsIndex = 0;
    
    
    public void SetIndex(int index)
    {
        skullsIndex = index;
    }

    public void HitSkull(int player)
    {
        {
            if (hittable)

            {
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Active");


                }
            }

        }
   


    }

    public void StopGame()
    {
       
        hittable = false;
        
    }
        
}