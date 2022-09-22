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

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        oneAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxis("Vertical");  
        vecPlayer.x = rigidB.velocity.x;
        vecPlayer.y = rigidB.velocity.y;
        oneAnim.SetBool("playerMoving", true);
        Jumping = false;

        if(vecPlayer.magnitude > 0)
        {
            oneAnim.SetBool("playerMoving", true);
        }else
        {
            oneAnim.SetBool("playerMoving", false);
        }

        if(Input.GetKey(KeyCode.Joystick1Button0))
        {
            oneAnim.SetBool("Attack", true);
        }
        if(Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            oneAnim.SetBool("Attack", false);
        }
       /* if( Horizontal < 0)
        {
            this.transform.localScale = new Vector3(-4, 4, 1);
            oneAnim.SetBool("playerMoving", true);
        }
        if (Horizontal > 0)
        {
          
            this.transform.localScale = new Vector3(4, 4, 1);
            oneAnim.SetBool("playerMoving", true);
        }*/
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
    private void FixedUpdate()
    {
        rigidB.velocity = new Vector2(Horizontal, Vertical) * speed;
     
        
    }
}

