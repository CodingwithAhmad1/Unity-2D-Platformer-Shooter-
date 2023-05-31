using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullHeal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        GameController controller = collision.gameObject.GetComponentInChildren<GameController>();
        
        if(controller){
            controller.FullHeal();
                Destroy(gameObject);
            }
        }
}
