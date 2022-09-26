using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health = 10;

	public bool isInvulnerable = false;

	public Animator anim;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 3)
		{
			GetComponent<Renderer>().material.color = Color.red;
		}

		if (health <= 0)
		{
			anim.SetBool("die", true);
			Destroy(gameObject);
		}
	}
}

