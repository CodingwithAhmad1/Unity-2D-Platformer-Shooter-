using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{

    Vector2 checkpointPos;

    public Transform firePoint;
    public GameObject bullet;

    public float startTimebetween;
    float timeBetween;


    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimebetween;
    }



    // Update is called once per frame
    void Update()
    {

    if (timeBetween <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            timeBetween = startTimebetween;
        }

    else
        {
            timeBetween -= Time.deltaTime;
        }
    }
        
}



