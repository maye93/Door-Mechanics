using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // public CharacterController controller;
    // private Rigidbody rb;
    // private Animator anim;

    // public float speed = 3f;

    // void Start() {
    //     rb = gameObject.GetComponent<Rigidbody>();
    //     anim = GetComponent<Animator>();
    // }

    // void Update() {
    //     float x = Input.GetAxis ("Horizontal");
    //     float z = Input.GetAxis ("Vertical");

    //     Vector3 move = transform.right * x + transform.forward * z;
    //     if(move != Vector3.zero){
    //         anim.SetBool("walking", true);
    //     } else {
    //         anim.SetBool("walking", false);
    //     }

    //     controller.Move(move * speed * Time.deltaTime);
    // }



    // public CharacterController controller;
    // private Rigidbody rb;
    // private Animator anim;

    // private float ySpeed;

    // public float speed = 3f;
    // public float gravity = -9.81f;
    // Vector3 velocity;

    // void Start()
    // {
    //     rb = gameObject.GetComponent<Rigidbody>();
    //     anim = GetComponent<Animator>();
    //     controller = GetComponent<CharacterController>();
    // }
    // void Update(){
    //     float x = Input.GetAxis("Horizontal");
    //     float z = Input.GetAxis("Vertical");
        
    //     Vector3 movementDirection = new Vector3(x, 0 ,z);
    //     float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
    //     movementDirection.Normalize();

    //     ySpeed += Physics.gravity.y * Time.deltaTime;

    //     // if(movementDirection != Vector3.zero){
    //     //     anim.SetBool("walking", true);
    //     // } else {
    //     //     anim.SetBool("walking", false);
    //     // }

        
    //     Vector3 velocity = movementDirection * magnitude;
    //     velocity.y -= 1f;

    //     Vector3 move = transform.right * x + transform.forward * z;
    //     controller.Move(velocity * Time.deltaTime);

    //     // velocity.y += gravity * Time.deltaTime;
    //     // controller.Move(velocity * Time.deltaTime);
    // }



    public CharacterController controller;
    private Rigidbody rb;
    private Animator anim;

    public float speed = 3f;
    public float gravity = -50f;
    // public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Vector3 movementDirection = new Vector3(x, 0 ,z);
        // if(movementDirection != Vector3.zero){
        //     anim.SetBool("walking", true);
        // } else {
        //     anim.SetBool("walking", false);
        // }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }



    // private CharacterController controller;
    // private Vector3 playerVelocity;
    // private bool groundedPlayer;
    // private float playerSpeed = 2.0f;
    // private float jumpHeight = 1.0f;
    // private float gravityValue = -9.81f;

    // private void Start()
    // {
    //     controller = gameObject.AddComponent<CharacterController>();
    // }

    // void Update()
    // {
    //     groundedPlayer = controller.isGrounded;
    //     if (groundedPlayer && playerVelocity.y < 0)
    //     {
    //         playerVelocity.y = 0f;
    //     }

    //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //     controller.Move(move * Time.deltaTime * playerSpeed);

    //     if (move != Vector3.zero)
    //     {
    //         gameObject.transform.forward = move;
    //     }

    //     // Changes the height position of the player..
    //     if (Input.GetButtonDown("Jump") && groundedPlayer)
    //     {
    //         playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //     }

    //     playerVelocity.y += gravityValue * Time.deltaTime;
    //     controller.Move(playerVelocity * Time.deltaTime);
    // }
}