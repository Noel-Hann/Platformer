using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody rb;

    public float acceleration = 10f;

    public float maxSpeed = 30f;

    public float jumpForce = 500;
    private Color rayColor;
    public float jumpBoost = 5;
    public Animator marioAnimator;
    public GameObject managerObject;
    private ScoreManager manager;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        marioAnimator = GetComponent<Animator>();
        manager = managerObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded )
        {
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //TODO eventually put this back in, but currently it lets you double jump and it should just increase jump height
        
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        */

        float velocity = rb.velocity.magnitude;
        marioAnimator.SetFloat("speed",velocity);
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        rb.velocity += Vector3.right * (horizontalAxis * Time.deltaTime * acceleration);
        if (rb.velocity.magnitude > maxSpeed)
        {
            //TODO figure out how to only clamp horizontal magnitude
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y;

        RaycastHit groundInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out groundInfo, halfHeight))
        {
            if (groundInfo.collider.gameObject.tag == "water")//if you touch water, kill mario
            {
                Debug.Log("Mario died");
                Destroy(this.gameObject);
            }
           // rayColor = Color.blue;
           isGrounded = true;
           
        }
        else
        {
            isGrounded = false;
            
        }
        RaycastHit hitInfo;
        //checks to see if you hit something with your head
        //Debug.DrawRay(transform.position,Vector3.up * 12,Color.blue,1);
        if (Physics.Raycast(transform.position, Vector3.up, out hitInfo, 12))
        {
            if (hitInfo.collider.gameObject.tag == "brick")
            {
                //manager.points += 100;
                Destroy(hitInfo.collider.gameObject);
                manager.points += 100;
            }
            else
            {
                Destroy(hitInfo.collider.gameObject);
            }
            
        }

        if (isGrounded)
        {
            rayColor = Color.red;
        }
        else
        {
            rayColor = Color.blue;
        }
        
        //rb.velocity = new Vector3(Mathf.Clamp(r))
        
        Debug.DrawLine(transform.position,transform.position + Vector3.down * halfHeight, rayColor, 0f);

        

        /*
         if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*jumpBoost);
        }*/
        
    }
}
