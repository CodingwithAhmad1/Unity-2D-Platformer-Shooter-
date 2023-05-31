using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image healthBar;
    public Enemy enemyHealth;
    public float healthAmount = 100f;
    int once;

    
    // Start is called before the first frame update
    void Start()
    {
        once = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if(healthAmount <= 0 && once == 0){
            once +=1;
            healthAmount = 0f;
            healthBar.fillAmount = healthAmount / 100f;
            healthBar.enabled = false;

        }
        if (once == 0){
        healthAmount = enemyHealth.health;
        healthBar.fillAmount = healthAmount / 100f;
        }

    }
}
