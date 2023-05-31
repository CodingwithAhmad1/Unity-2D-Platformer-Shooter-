using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth;
    float weapon;
    float damage;

    private void Start()
    {
        health = maxHealth;
        weapon = 0;
        damage = 8;
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            weapon += 1;

            if (weapon == 0){
                damage = 8;
            }
            else if(weapon == 1){
                damage = 22;
            }

            else if(weapon == 2){
                damage = 4;
            }

            else if (weapon == 3){
                weapon -= 3;
                damage = 5;
            }
        }
        
    }

    public void TakeDamage(float damageAmount)
    {
        damageAmount = damage;

        health -= damageAmount; // 3-> 2 -> 1 -> 0 = Enemy has died
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }



}
