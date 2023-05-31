using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCannon : MonoBehaviour
{
    Vector2 checkpointPos;

    public Transform firePoint;
    public GameObject bullet;
    public float startTimebetween;
    
    float timeBetween;
    int once;

    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimebetween;
        once = 0;
    }



    // Update is called once per frame
    void Update()
    {

        if(once == 0){
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            once += 1;
        }
        
    }
}
