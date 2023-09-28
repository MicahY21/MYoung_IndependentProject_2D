using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float directionx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionx * 7f, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
           rb.velocity = new Vector2(rb.velocity.x, 14f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
