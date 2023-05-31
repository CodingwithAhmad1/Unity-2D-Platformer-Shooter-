using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoReload : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        Weapon weapon = collision.gameObject.GetComponentInChildren<Weapon>();
        
        if(weapon){
            weapon.AddAmo(weapon.maxAmmoSize);
                Destroy(gameObject);
            }
        }
}

