using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainthrust = 1000f;
    [SerializeField] float rotatethrust = 100f;

    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         audiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        processthrust();
        processrotation();
    } 

    void processthrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*mainthrust*Time.deltaTime);
            if(!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
        }
    }

    void processrotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            applyrotation(rotatethrust);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            applyrotation(-rotatethrust);
        }
    }

    void  applyrotation(float rotationthisframe)
    {
        rb.freezeRotation = true ;  // freezing the rotations so that we can logically rotate the body instead and without alowing the physics system to do its work
        transform.Rotate(Vector3.forward*rotationthisframe*Time.deltaTime);
        rb.freezeRotation = false ;     //now we are just unfreezing it 
    }

}
