using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniHeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        GameController controller = collision.gameObject.GetComponentInChildren<GameController>();
        
        if(controller){
            controller.MiniHeal(10);
                Destroy(gameObject);
            }
        }
}
