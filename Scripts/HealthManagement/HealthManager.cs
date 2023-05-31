using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public GameController gameController;
    public float healthAmount = 100f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(healthAmount <= 0){
            healthAmount = 100f;
            healthBar.fillAmount = healthAmount / 100f;
        }

        healthAmount = gameController.health;
        healthBar.fillAmount = healthAmount / 100f;

    }
}
