using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    public string PlayerInputTag;
    public Animator anim;
    public float DashSpeed;
    public float DashCD;

    private bool canDash = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
		speed = gameObject.GetComponent<PlayerBehavior>().Speed;
        
    }

    // Update is called once per frame
    void Update()
    {
		
        anim.SetBool("isRunning", false);
        if (Input.GetAxis(PlayerInputTag + " Joy X") != 0)
        {
            rb.AddForce(new Vector2(Input.GetAxis(PlayerInputTag + " Joy X") * speed, 0));
            if (Input.GetAxis(PlayerInputTag + " Joy X") >= 0.05 || Input.GetAxis(PlayerInputTag + " Joy X") <= -0.05)
            {
                anim.SetBool("isRunning", true);
            }           
        }
        if (Input.GetAxis(PlayerInputTag + " Joy Y") != 0)
        {
            rb.AddForce(new Vector2(0, -Input.GetAxis(PlayerInputTag + " Joy Y") * speed));
			if (Input.GetAxis(PlayerInputTag + " Joy Y") >= 0.05 || Input.GetAxis(PlayerInputTag + " Joy Y") <= -0.05)
            {
                anim.SetBool("isRunning", true);
            }
        }
        //Debug.Log("x=" + Input.GetAxis("Joy X") + " // y=" + Input.GetAxis("Joy Y"));
        //Debug.Log(Input.GetKey("joystick button 1"));

        if (canDash && Input.GetButton(PlayerInputTag +" Dash"))
        {
            canDash = false;
            StartCoroutine(DashCooldown());
        }

    }

    IEnumerator DashCooldown()
    {
        PlayerDash();
        yield return new WaitForSeconds(DashCD);
        Debug.Log("ready");
        canDash = true;
    }

    public void PlayerDash()
    {
        Debug.Log("Just Dashed");
        rb.AddForce(new Vector2(Input.GetAxis(PlayerInputTag + " Joy X" ) * DashSpeed, -Input.GetAxis(PlayerInputTag + " Joy Y") * DashSpeed));
    }
}
