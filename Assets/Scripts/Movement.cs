using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust = 1000f, rotateSpeed = 150f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space) )
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
            rb.AddRelativeForce(Vector3.left);
        }else if(Input.GetKey(KeyCode.D) )
        {
            ApplyRotation(-rotateSpeed);
            rb.AddRelativeForce(Vector3.right);
        }else if(Input.GetKey(KeyCode.S) )
        {
            
            rb.AddRelativeForce(Vector3.down);
        }
    }
    void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
