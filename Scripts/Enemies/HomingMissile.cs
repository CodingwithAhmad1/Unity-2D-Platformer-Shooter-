using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    private Rigidbody2D rb2;
    public GameObject player; // player target
    public Transform target;

    float distance;
    public float playerDistanceAway;

    
    public float speed;
    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        
        speed = 5f;

        rotateSpeed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
    }

    void FixedUpdate(){
        if (distance < playerDistanceAway){
        Vector2 direction = (Vector2)target.position - rb2.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb2.angularVelocity = -rotateAmount * rotateSpeed;

        rb2.velocity = transform.up * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
        Destroy(gameObject);
        }
    }
}
