using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonRight : MonoBehaviour
{
    Vector2 checkpointPos;

    public Transform firePoint;
    public GameObject RightBullet;
    public float startTimebetween;
    
    float timeBetween;
    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimebetween;
        shoot = false;
    }



    // Update is called once per frame
    void Update()
    {

        if(shoot){
            if (timeBetween <= 0)
            {
                Instantiate(RightBullet, firePoint.position, firePoint.rotation);
                timeBetween = startTimebetween;
            }
            else
            {
                timeBetween -= Time.deltaTime;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision){
        shoot = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        shoot = false;
    }
}
