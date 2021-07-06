using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //LeftRightSpeed
    Rigidbody rb;
    public float jumpTime = 0.65f;
    public bool jumping = false;
    float jumpTimer = 0;

    public float slideTime = 0.65f;
    public bool sliding = false;
    float slideTimer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NormalHitbox")
        {
            GameController.Instance.menuController.OnLose();
        }
        if (other.tag == "JumpHitbox" && !jumping)
        {
            GameController.Instance.menuController.OnLose();
        }
        if (other.tag == "SlideHitbox" && !sliding)
        {
            GameController.Instance.menuController.OnLose();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //KEYBOARDCONTROLS
        if(jumping)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= jumpTime)
            {
                jumping = false;
                jumpTimer = 0;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
        if (sliding)
        {
            slideTimer += Time.deltaTime;
            if (slideTimer >= slideTime)
            {
                sliding = false;
                slideTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(rb.position.x >= -6.5f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 5);

            }
            
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.position.x <= 1f)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 5);
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && !sliding)
        {
            GetComponent<Animator>().SetTrigger("Jump");
            jumping = true;
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !jumping)
        {
            GetComponent<Animator>().SetTrigger("Slide");
            sliding = true;
        }
    }
}
