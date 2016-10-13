using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public bool doubleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        this.myRigidbody = GetComponent<Rigidbody2D>();
        this.myCollider = GetComponent<Collider2D>();
        this.myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        this.myRigidbody.velocity = new Vector2(this.moveSpeed, this.myRigidbody.velocity.y);
        this.grounded = Physics2D.IsTouchingLayers(this.myCollider, this.whatIsGround);

        if (this.grounded)
        {
            this.doubleJump = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (this.grounded)
            {
                this.myRigidbody.velocity = new Vector2(this.myRigidbody.velocity.x, this.jumpForce);
            }
            else if(!this.grounded && this.doubleJump)
            {
                this.doubleJump = false;
                this.myRigidbody.velocity = new Vector2(this.myRigidbody.velocity.x, this.jumpForce);
            }
        }

        this.myAnimator.SetFloat("Speed",this.myRigidbody.velocity.x);
        this.myAnimator.SetBool("Grounded", this.grounded);


    }
}
