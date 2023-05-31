using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingPad : MonoBehaviour
{
    public float healing;
    private void OnTriggerStay2D(Collider2D collision){
        GameController controller = collision.gameObject.GetComponentInChildren<GameController>();
        
        if(controller){
            controller.health += healing;
            }
     }
}
