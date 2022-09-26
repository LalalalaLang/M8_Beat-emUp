using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public int damageAtt;
    public int damageSla;
    private float timeBtwDamage = 1.5f;

    //public Animator camAnim;
    public Slider healthBar;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("die", false);

        if (health <= 0)
        {
            anim.SetBool("die", true);

            //give player some time to recover before taking more damage
            if (timeBtwDamage > 0)
            {
                timeBtwDamage -= Time.deltaTime;
            }

            healthBar.value = health;
        }
        
        /*private void onTriggerEnter2D(Collider2D other)
        {
            //deal the player damage
            if (other.CompareTag("Player")) { }


            if (timeBtwDamage <= 0)
            {
            }


        }*/
    } }

