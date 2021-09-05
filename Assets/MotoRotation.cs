using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoRotation : MonoBehaviour
{
    public WheelMovemet frontWheel, backWheel;
    public float rotation, rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        rotation = Input.GetAxis("Vertical") * rotationSpeed;
        if (rotation < 0)
        {
            backWheel.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Abs(rotation)));
            print("key donw and rotation value is "+Mathf.Abs(rotation));
        }
        else if (rotation > 0)
        {
            frontWheel.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, rotation));
            print("key up and rotation value is " + rotation);

        }

    }
}
