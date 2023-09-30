using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSmash : MonoBehaviour
{
    const string PRESS_ANIM = "ClickHand";
    const string IDEL_ANIM = "IdelHand";
    Animator myAnimator;



    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        
    }

    

    public void Update()
    {
       

        if (Input.GetMouseButtonDown(0))
        {  

            {


                myAnimator.SetTrigger(PRESS_ANIM);
            }
            
        }

            
        else
        {

            myAnimator.SetTrigger(IDEL_ANIM);
        }


    }

  
}
