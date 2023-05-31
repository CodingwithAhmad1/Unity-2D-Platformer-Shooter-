using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftController : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 TargetPos;

    // Start is called before the first frame update
    void Start()
    {
        TargetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f && Input.GetKeyDown(KeyCode.F)){ // click F to move platform
        TargetPos = posB.position;
        }

        if (Vector2.Distance(transform.position, posB.position) < .1f && Input.GetKeyDown(KeyCode.F)){
            TargetPos = posA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
