using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthLife : MonoBehaviour
{
    [SerializeField] private float startHealth;

    public float currentHealth { get; private set; }

    private Animator anim;
    private bool dead;


    private void Awake()
    {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth); // pas moins de 0 et pas plus du maxHealth possible

        if (currentHealth > 0)
        {
            anim.SetBool("hurt", true);
        }
        else
        {
            if (dead)
            {
                anim.SetBool("die", true);
                //GetComponent<playerConnard>().enabled = false; ==> plus rien s'il s'agit du script player
                dead = true;
            }

        }
    }
}
