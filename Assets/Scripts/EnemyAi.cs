using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public Transform target;
    public float speed = 5;
    public float physicalDistance = 5;
    public float airDistance = 8;
    public float getAwayDiatance = 3;
    public float health = 100;

    bool jumped = false;

    [Header("RayCast")]
    public LayerMask layer_mask;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (3 - 1) * Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, target.position) >= physicalDistance && 
            Vector2.Distance(transform.position, target.position) >= airDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            StartCoroutine(JumpOnce());
        }
        else if (Vector2.Distance(transform.position, target.position) >= physicalDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
        if(Vector2.Distance(transform.position, target.position) <= getAwayDiatance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }


        CheckRayCast();
    }


    IEnumerator JumpOnce()
    {
        if (!jumped)
        {
            jumped = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 6;
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 7;
            yield return new WaitForSeconds(1f);
            jumped = false;
        }

    }



    public void CheckRayCast()
    {
        var dir = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 50f, ~layer_mask);

        Debug.DrawRay(transform.position, dir, Color.green);

        if (hit.collider.tag == "Player")
        {
            EnemyBullet.playerVisible = true;
        }
        else
        {
            EnemyBullet.playerVisible = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 10;
            Destroy(collision.gameObject);
        }
    }
}
