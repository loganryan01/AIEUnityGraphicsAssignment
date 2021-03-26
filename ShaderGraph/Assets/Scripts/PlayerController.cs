using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public float speed;
    public Rigidbody playerRB;
    public bool IsGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fwd = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(right * speed * Time.deltaTime, 0, fwd * speed * Time.deltaTime);

        transform.Translate(move);

        playerAnimator.SetFloat("Ypos", fwd);
        playerAnimator.SetFloat("Xpos", right);
        //playerAnimator.SetFloat("SpeedMod", speed);

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(WaitAndJump());
        }

        if (Input.GetButtonDown("Fire3"))
        {
            playerAnimator.SetBool("IsPunching", true);
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            playerAnimator.SetBool("IsPunching", false);
        }

        if (Input.GetMouseButton(1))
        {
            playerAnimator.SetBool("IsAiming", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            playerAnimator.SetBool("IsAiming", false);
        }
    }

    private void FixedUpdate()
    {
        int layerMask = 1 << 8;
        float distance = 2;

        layerMask = ~layerMask;
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), distance) && playerRB.velocity.y < 0)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * distance, Color.yellow);
            playerAnimator.SetBool("IsGrounded", true);
            playerAnimator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("IsGrounded", false);
        }
    }

    IEnumerator WaitAndJump()
    {
        playerAnimator.SetBool("IsJumping", true);

        Vector3 jump = new Vector3(0, 10, 0);

        yield return new WaitForSeconds(0.4f);

        playerRB.AddForce(jump, ForceMode.Impulse);
    }
}
