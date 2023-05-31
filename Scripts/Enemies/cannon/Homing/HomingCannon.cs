using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCannon : MonoBehaviour
{
    Vector2 checkpointPos;

    public Transform firePoint;
    public GameObject homingMissile;
    public float startTimebetween;
    
    float timeBetween;
    bool shoot;
    int once;

    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimebetween;
        shoot = false;
        once = 0;
    }



    // Update is called once per frame
    void Update()
    {

        if(shoot && once == 0){
            Instantiate(homingMissile, firePoint.position, firePoint.rotation);
            once += 1;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision){
        shoot = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        shoot = false;
    }
}
