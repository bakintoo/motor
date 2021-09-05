using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovemet : MonoBehaviour
{
    public float speed;
    float movement;
    Rigidbody2D rb;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isGrounded) return;
        movement = Input.GetAxisRaw("Vertical") * speed;
        rb.AddForce(new Vector2(movement, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided!!");
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        print("not collided!!");

        isGrounded = false;
    }
}
