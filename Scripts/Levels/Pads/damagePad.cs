using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePad : MonoBehaviour
{
    public float damage;

    private void OnTriggerStay2D(Collider2D collision){
        GameController controller = collision.gameObject.GetComponentInChildren<GameController>();
        
        if(controller){
            controller.health -= damage;
            StartCoroutine(waiter());
            }
        
    }

    IEnumerator waiter()
    {
    //Wait for 0.35 seconds
    yield return new WaitForSeconds(0.35f);
    }

}
