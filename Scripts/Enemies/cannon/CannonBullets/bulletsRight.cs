using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsRight : MonoBehaviour
{
    // shooting left direction
    public float speed;
    Rigidbody2D bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = transform.right * speed;
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D other){
        Destroy(gameObject);
    }
}
