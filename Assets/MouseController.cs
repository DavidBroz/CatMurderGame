using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject atMouseHole;

    public float mouseSpeed;
    public bool isFacingRight=true;

    public bool stunned = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        if (hor != 0 && !stunned) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(mouseSpeed * hor, 0, 0);

            if (hor > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (hor < 0 && isFacingRight) { 
                Flip(); 
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && atMouseHole!=null && !stunned)
        {
            transform.position = atMouseHole.GetComponent<MouseHole>().otherMouseHole.transform.position;

        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.eulerAngles += new Vector3(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MouseHole")) {
            atMouseHole = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(atMouseHole))
        {
            atMouseHole=null;
        }
    }
}
