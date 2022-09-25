using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class animBreak : MonoBehaviour
{
    public Animator waterFountain;
    public TagAttribute Player;
    private Collider2D target;

    // Start is called before the first frame update
    void Start()
    {
        waterFountain.SetBool("empty", false);
        target = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            waterFountain.SetBool("empty", true);
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
