using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    #region Fields
    public float jumpSpeed = 5;
    public float speed = 10;
    public float health = 100;

    Rigidbody2D rb;
    #endregion

    #region Monobehaviour
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10;
            Destroy(collision.gameObject);
        }
    }

    #endregion

    #region private methods

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += speed * -transform.right * Time.deltaTime;
        }


        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }

    #endregion

}
