using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public static bool shootCooldown = false;
    [SerializeField]
    public static bool playerVisible = false;

    public GameObject bulletGameobject;
    public Transform target;
    public float speed;

    private GameObject bullet;


    private void Update()
    {

        if (!shootCooldown)
        {
            shootCooldown = true;
            StartCoroutine(shootColldown());
            Shoot();
        }
    }

    public void Shoot()
    {
        if(playerVisible)
        {
            Vector2 dir = (Vector2)((target.position - transform.position));
            dir.Normalize();

            bullet = (GameObject)Instantiate(bulletGameobject, 
                transform.position + (Vector3)(dir * 0.5f), Quaternion.identity);

            Destroy(bullet, 0.5f);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    IEnumerator shootColldown()
    {
        yield return new WaitForSeconds(0.3f);
        shootCooldown = false;
    }

}
