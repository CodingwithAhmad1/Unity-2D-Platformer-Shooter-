using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // this script manages player interactions and respaw


    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    private TrailRenderer trail;
    Rigidbody2D rb1;

    // health
    public float health, maxHealth;

    // deaths
    public int deaths;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb1 = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        checkpointPos = transform.position;
        maxHealth = 100;
        health = maxHealth;
        deaths = 0;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
            checkpointPos = transform.position;
        }

        if (collision.CompareTag("Spike"))
        {
            health -= 5;
            rb1.velocity = new Vector2(rb1.velocity.y, 10);
        }

        if (collision.CompareTag("cannon10DPS"))
        {
            health -= 5;
        }

        if (collision.CompareTag("cannon15DPS"))
        {
            health -= 7.5f;
        }

        if (collision.CompareTag("cannon20DPS"))
        {
            health -= 10;
        }

        if (collision.CompareTag("Missile25DPS"))
        {
            health -= 12.5f;
        }

        if (collision.CompareTag("autoBullet18DPS"))
        {
            health -= 9;
        }

        if (collision.CompareTag("fast7DPS"))
        {
            health -= 5;
        }


        if (collision.CompareTag("Respawn!"))
        {
            Die();
        }
    }

    void Update(){
        if (health > maxHealth){
            health = maxHealth;
        }
        
        if (health <= 0){
            Die();
        }

    }

    public void FullHeal(){
        health = maxHealth;
    }

    public void MiniHeal(int healAmount){
        health += healAmount;
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
        deaths += 1;
    }

    IEnumerator Respawn(float duration)
    {
        rb1.simulated = false;
        gameObject.GetComponent<TrailRenderer>().enabled=false; 
        transform.localScale = new Vector3(0, 0, 0);

        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        spriteRenderer.enabled = true;

        transform.localScale = new Vector3(1, 1, 1);
        rb1.simulated = true;
        gameObject.GetComponent<TrailRenderer>().enabled=true; 
        health = maxHealth;
    }
  
    
}
