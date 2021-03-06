using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrWheel : MonoBehaviour
{
    private  Rigidbody2D rb;
    [Header("Suspension")]
    public float restLenght, springTravel, springStifness, damperStifness;
    private float minLenght, maxLenght, springLenght, springForce, lastLenght, damperForce, springVelocity;
    private Vector2 suspensionForce;
    RaycastHit2D hit;

    [Header("Wheels")]
    public float wheelRedius;
    private Vector2 wheelVelocityLS;
    private float fX;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.root.GetComponent<Rigidbody2D>();

        minLenght = restLenght - springTravel;
        maxLenght = restLenght + springTravel;

    }
    void Update()
    {

    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position, -transform.up, maxLenght + wheelRedius);
       if (hit && hit.transform.gameObject.tag == "Map")
        {
           // Debug.DrawRay(transform.position, -transform.up, Color.red, 0.5f);

            lastLenght = springLenght;
            springLenght = hit.distance - wheelRedius;
            springLenght = Mathf.Clamp(springLenght, minLenght, maxLenght);
            springVelocity = (lastLenght - springLenght) / Time.fixedDeltaTime;
            springForce = springStifness * (restLenght - springLenght);
            damperForce = damperStifness * springVelocity;
            suspensionForce = (springForce + damperForce) * transform.up;
            // print(suspensionForce);

            wheelVelocityLS = transform.InverseTransformDirection(rb.GetPointVelocity(hit.point));
            fX = Input.GetAxis("Vertical") * springForce;

            if((suspensionForce + (new Vector2(transform.right.x, transform.right.y) * fX), hit.point).point.y < 0)
            rb.AddForceAtPosition(suspensionForce + (new Vector2(transform.right.x, transform.right.y) * fX), hit.point);
            print(transform.right * fX);
        }
    }
}
