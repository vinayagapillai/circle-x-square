using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Feilds
    public Transform gunLocation;
    public float speed = 5;
    public GameObject bulletGameobject;

    //private Rigidbody2D bullet;
    private Vector3 shootDirection;
    private bool inCooldown = false;


    #endregion

    #region Monobehaviour
    private void Awake()
    {
        //bullet = bulletGameobject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //StartCoroutine(SelfDestroy());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !inCooldown)
        {
            inCooldown = true;
            StartCoroutine(shootColldown());
            shoot();
        }
    }
    #endregion

    #region private methods
    private void shoot()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                bulletGameobject,
                                transform.position + (Vector3)(direction * 0.5f),
                                Quaternion.identity);
        Destroy(bullet, 0.5f);

        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;


    }
    #endregion

    #region Couroutines
    IEnumerator shootColldown()
    {
        yield return new WaitForSeconds(0.1f);
        inCooldown = false;
    }

    #endregion
}
