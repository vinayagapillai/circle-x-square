using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour
{
    public PhotonView PhotonView;
    public GameObject playerCamera;

    public float moveSpeed;
    public float jumpSpeed;

    Rigidbody2D rb;

    private void Awake()
    {
        if (PhotonView.isMine)
        {
            playerCamera.SetActive(true);
        }
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PhotonView.isMine)
        {
            playerMovement();
        }
    }

    private void playerMovement()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey("space"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2 - 1) * Time.deltaTime;
        }
    }

}
