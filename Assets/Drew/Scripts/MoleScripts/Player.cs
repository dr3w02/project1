using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public int playerIndex;
    public Mole currentMole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Wack();
        }
    }

    public void Wack()
    {
        if(currentMole != null)
        {
            currentMole.HitMole(playerIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mole")
        {
            currentMole = collision.GetComponent<Mole>();
           

          

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mole")
        {
            currentMole = null;
        }
    }
}
