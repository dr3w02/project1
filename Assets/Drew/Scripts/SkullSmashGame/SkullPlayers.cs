using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPlayers : MonoBehaviour
{
  
    public int playerIndex;
    public SkullSmash currentSkull;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Wack();
        }
    }

    public void Wack()
    {
        if (currentSkull != null)
        {
            currentSkull.HitSkull(playerIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            currentSkull = collision.GetComponent<SkullSmash>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            currentSkull = null;
        }
    }
}

