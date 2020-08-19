using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
    public Rigidbody rb;
    public int speed = 100;



    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * speed* Time.deltaTime);
           
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * speed* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed* Time.deltaTime);
        }
    }
    
    /*
    void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
    */
}
