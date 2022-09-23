using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerOne : MonoBehaviour
{
    private Rigidbody2D rigidB;
    private Vector2 vecPlayer;
    public float speed;
    public Animator oneAnim;
    public float Horizontal;
    public float Vertical;
    public bool Jumping;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponentInParent<Rigidbody2D>();
        oneAnim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        vecPlayer.x = rigidB.velocity.x;
        vecPlayer.y = rigidB.velocity.y;
        rigidB.velocity = new Vector2(Horizontal, Vertical) * speed;

        //image du perso s'inverse lorsqu'il tourne
        if (Horizontal < 0)
        {
            this.transform.localScale = new Vector3(-4, 4, 1);
            oneAnim.SetBool("playerMoving", true);
        }
        if (Horizontal > 0)
        {
            this.transform.localScale = new Vector3(4, 4, 1);
            oneAnim.SetBool("playerMoving", true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        //input pour se déplacer (pas encore au point, trouver pourquoi)
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
      

        oneAnim.SetBool("playerMoving", true);
        Jumping = false;

        //activation animation walk
        if(vecPlayer.magnitude > 0)
        {
            oneAnim.SetBool("playerMoving", true);
        }else
        {
            oneAnim.SetBool("playerMoving", false);
        }

        //fonction animation attack
        if(Input.GetKey(KeyCode.Joystick1Button0))
        {
            oneAnim.SetBool("Attack", true);
        }

        if(Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            oneAnim.SetBool("Attack", false);
        }
 
        //fonction animation jump
        if (Input.GetKey(KeyCode.JoystickButton1))
        {
            Jumping = true;
            oneAnim.SetBool("jumping", true);
        }
        
        if(Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            Jumping = false;
            oneAnim.SetBool("jumping", false);
        }
    }
}

