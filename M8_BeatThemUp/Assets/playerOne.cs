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
        Vertical = Input.GetAxisRaw("Vertical");
        Vector2 movePlayerOne = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        vecPlayer = movePlayerOne.normalized * speed;
        oneAnim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));

        oneAnim.SetBool("Attack", false);

        if (Input.GetKey(KeyCode.JoystickButton1))
        {
            oneAnim.SetBool("Attack", true);
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            oneAnim.SetBool("Attack", false);
        }
      
    }

}

