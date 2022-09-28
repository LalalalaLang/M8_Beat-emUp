using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FollowPlayer
{
    public class EnemyFollow : MonoBehaviour

    {

        public float speed;
        public float checkRadius;
        public float attackRadius;

        public LayerMask towardsWho;

        private Transform target;
        private Rigidbody2D rb;
        private Animator anim;
        private Vector2 movement;

        private float Horizontal;

        private bool isInChaseRange;
        private bool isInAttackRange;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponentInChildren<Rigidbody2D>();
            anim = GetComponentInChildren<Animator>();
            target = GameObject.FindWithTag("Player").transform;
        }


        // Update is called once per frame
        void Update()
        {
            anim.SetBool("walk", true);
            //radius de chasse
            isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, towardsWho);
            //le radius d'attack
            isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, towardsWho);

            // difference de distance player-boss
            movement = target.position - transform.position;
            //calcul du périmètre de poursuite
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            movement.Normalize();
            Horizontal = movement.x;

            //boss peut se tourner 
            if (Horizontal < 0)
            {
                this.transform.localScale = new Vector3(-5, 5, 1);
                anim.SetBool("walk", true);
            }
            if (Horizontal > 0)
            {
                this.transform.localScale = new Vector3(5, 5, 1);
                anim.SetBool("walk", true);
            }


        }

        private void FixedUpdate()
        {
            if (isInChaseRange && !isInAttackRange)
            {
                MoveCharacter(movement);
            }
            if (isInAttackRange)
            {
                rb.velocity = Vector2.zero;
            }
        }

        private void MoveCharacter(Vector2 direction)
        {
            rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

        }
    }
}