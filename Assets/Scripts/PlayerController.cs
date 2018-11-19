using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
public class PlayerController : MonoBehaviour {

public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
    public Texture2D fadeImage;
	private Rigidbody rigidbody;
	private Collider collider;
	private LayerMask playermask;

 
	void Awake () {
		rigidbody = GetComponent<Rigidbody>();
	    rigidbody.freezeRotation = true;
	    rigidbody.useGravity = false;
		collider = GetComponent<CapsuleCollider>();
		playermask = LayerMask.GetMask("Default");
	}
 
	void FixedUpdate () {
        if(isFalling())
        {
            Death();
        }
	    if (isGrounded()) {
	        // Calculate how fast we should be moving
	        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	        targetVelocity = transform.TransformDirection(targetVelocity);
	        targetVelocity *= speed;
 
	        // Apply a force that attempts to reach our target velocity
	        Vector3 velocity = rigidbody.velocity;
	        Vector3 velocityChange = (targetVelocity - velocity);
	        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
	        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
	        velocityChange.y = 0;
	        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
 
	        // Jump
	        if (canJump && Input.GetButton("Jump")) {
	            rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
	        }
	    }
        else //slow in air movement
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rigidbody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x *.05f, -maxVelocityChange * .05f, maxVelocityChange * .05f);
            velocityChange.z = Mathf.Clamp(velocityChange.z * .05f, -maxVelocityChange * .05f, maxVelocityChange * .05f);
            velocityChange.y = 0;
            rigidbody.AddForce(velocityChange , ForceMode.VelocityChange);
        }
 
	    // We apply gravity manually for more tuning control
	    rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
	}
    bool isFalling()
    {
        return transform.position.y < 20f;
    }
 
    void Death()
    {
        //Destroy(this.gameObject);
        Application.LoadLevel(1);
    }
	/*void OnCollisionStay () {
	    grounded = true;    
	}*/
	bool isGrounded()
	{
		//Debug.Log("center x: " + collider.bounds.center.x);
		//Debug.Log("min y: " + collider.bounds.min.y);
		//Debug.Log("center z: " + collider.bounds.center.z);
		//playermask = ~playermask;
		return  Physics.CheckCapsule(collider.bounds.center,new Vector3(collider.bounds.center.x,collider.bounds.min.y-0.18f,
		collider.bounds.center.z),0.3f, playermask);
	}
 
	float CalculateJumpVerticalSpeed () {
	    // From the jump height and gravity we deduce the upwards speed 
	    // for the character to reach at the apex.
	    return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}