using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerSkull : MonoBehaviour
{


    public int skullIndex;
    public SkullSmash currentSkull;


    public int playerIndex;
    public Mole currentMole;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] PlayerInput _playerInput;



    private void OnValidate()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        float horizontal = _playerInput.actions["Movement"].ReadValue<Vector2>().x;
        bool click = _playerInput.actions["Click"].WasPressedThisFrame();

        if (click)
        {
            Wack();
        }
    }


    public void Wack()
    {
        if (currentSkull != null)
        {
            currentSkull.HitSkull(skullIndex);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Smash")
        {
            currentSkull = collision.GetComponent<SkullSmash>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Smash")
        {
            currentSkull = null;
        }
    }
}



