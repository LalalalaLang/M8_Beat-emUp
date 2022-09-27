using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image maxhealthBar;
    [SerializeField] private Image currenthealthBar;


    // Start is called before the first frame update
    void Start()
    {
        maxhealthBar.fillAmount = playerHealth.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth;
    }
}
