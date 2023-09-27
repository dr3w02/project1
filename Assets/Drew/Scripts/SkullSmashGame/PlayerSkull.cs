using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkull : MonoBehaviour
{


    public int skullIndex;
    public SkullSmash currentSkulls;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Wack1();
        }
    }

    public void Wack1()
    {
        if (currentSkulls != null)
        {
            currentSkulls.HitSkull(skullIndex);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            currentSkulls = collision.GetComponent<SkullSmash>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            currentSkulls = null;
        }
    }
}



