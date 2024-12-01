using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 5f;
    private Vector3 local_scale;
    private Animator animator;
    private bool grounded;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        local_scale = transform.localScale;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal_Input = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontal_Input * speed, body.linearVelocity.y);

        // Flip player for left & right movement
        if (horizontal_Input > 0.01f)
        {
            transform.localScale = new Vector3(local_scale.x, local_scale.y, local_scale.z);
        }
        else if (horizontal_Input < -0.01f)
        {
            transform.localScale = new Vector3(-1 * local_scale.x, local_scale.y, local_scale.z);
        }

        // Jump logic
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        // Set Animator parameters
        animator.SetBool("run", horizontal_Input != 0);
        animator.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        animator.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
