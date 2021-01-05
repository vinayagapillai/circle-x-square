using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public Transform target;
    public LayerMask layer_mask;


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position, 
            Vector2.Distance(transform.position, target.position));
        //Debug.DrawRay(transform.position, target.position, Color.green);


        if (hit)
        {
            Debug.Log(hit.collider.name);
            Debug.DrawLine(transform.position, hit.point, Color.red);

        }
    }

}
