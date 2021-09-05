using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovemet : MonoBehaviour
{
    enum WheelState { front, back};
    [SerializeField] WheelState wheelState;
    public float speed, rotationSpeed;
    float movement;
    Rigidbody2D rb;
    bool isGrounded;

    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //if (!isGrounded) return;
        movement = Input.GetAxisRaw("Horizontal") * speed;
       rotation = Input.GetAxis("Horizontal") * rotationSpeed;


        rb.AddForce(new Vector2(movement, 0));

      /*  if(wheelState == WheelState.front && rotation > 0)
        {
            rb.AddForce(new Vector2(0, rotation));
        }
        else if (wheelState == WheelState.back && rotation < 0)
        {
            rb.AddForce(new Vector2(0, -rotation));
        } */ 


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
