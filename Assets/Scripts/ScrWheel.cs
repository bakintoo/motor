using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrWheel : MonoBehaviour
{
    public  Rigidbody2D rb;
    [Header("Suspension")]
    public float restLenght, springTravel, springStifness;
    private float minLenght, maxLenght, springLenght, springForce;
    private Vector2 suspensionForce;

    [Header("Wheels")]
    public float wheelRedius;

    // Start is called before the first frame update
    void Start()
    {
        minLenght = restLenght - springTravel;
        maxLenght = restLenght + springTravel;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLenght + wheelRedius))
        {
            print("i hit");
            springLenght = hit.distance - wheelRedius;
            springForce = springStifness * (restLenght - springLenght);
            suspensionForce = springForce * transform.up;
            rb.AddForceAtPosition(suspensionForce, hit.point);
        }
    }
}
