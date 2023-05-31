using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D gunBullet;
    public float bulletSpeed;
    float horizontal;
    public float weapon;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        gunBullet = GetComponent<Rigidbody2D>();

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        gunBullet.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        Destroy(gameObject, 5);

        weapon = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // enemies get damaged

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {

            enemyComponent.TakeDamage(1);

        }

        Destroy(gameObject);

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            weapon += 1;
        }
        
    }
}




