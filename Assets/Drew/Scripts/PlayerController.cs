using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{

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
        if (currentMole != null)
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

    /*
    private CharacterController controller;

    private Vector2 movementInput = Vector2.zero;
    private bool clicked = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
  
        
    public void OnClick(InputAction.CallbackContext context)
    {
        clicked = context.action.triggered;
    }


    void Update()
    {
       

        Vector3 move = new Vector3(movementInput.x, 0 , movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        
        // Changes the height position of the player..
        if (clicked)
        {
            Wack();
        }

        
    }
    public void Wack()
    {
        if (currentMole != null)
        {
            currentMole.HitMole(playerIndex);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Mole")
        {
            currentMole = collision.GetComponent<Mole>();




        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Mole")
        {
            currentMole = null;
        }
    }



}
    */
