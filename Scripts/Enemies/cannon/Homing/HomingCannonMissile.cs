using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCannonMissile : MonoBehaviour
{
    // elements
    private Rigidbody2D rb2;
    public GameObject player;
    public Transform target;

    
    // respawning
    public Transform respawn;
    bool respawning;
 
    // movement
    public float rotateSpeed;
    public float speed;

    // health
    public float health, maxHealth;
    float weapon;
    float damage;

    // trigger
    public float playerDistanceAway;
    float distance;


    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rotateSpeed = 240f;
        respawning = false;

        health = maxHealth;

        weapon = 0;
        damage = 8;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector2.Distance(transform.position, player.transform.position);

        if(Input.GetKeyDown(KeyCode.Q)){
            weapon += 1;

            if (weapon == 0){
                damage = 8;
            }
            else if(weapon == 1){
                damage = 22;
            }

            else if(weapon == 2){
                damage = 4;
            }

            else if (weapon == 3){
                weapon -= 3;
                damage = 5;
            }
        }


        if (health <= 0){
            health = maxHealth;
            respawning = true;
        }

    }

    void FixedUpdate(){

        if(!respawning && distance < playerDistanceAway){
        Vector2 direction = (Vector2)target.position - rb2.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb2.angularVelocity = -rotateAmount * rotateSpeed;

        rb2.velocity = transform.up * speed;
        }

        if(respawning){
        transform.position = new Vector2 (respawn.position.x, respawn.position.y);
        respawning = false;
        StartCoroutine(wait());
        }

    }



    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            respawning = true;
        }

        if(collision.CompareTag("gunBullet")){
            health -= damage;
        }
    }

    public IEnumerator wait(){
     yield return new WaitForSeconds (3);
    }


}

