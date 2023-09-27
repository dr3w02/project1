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