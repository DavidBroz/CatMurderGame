using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{

    public float movementSpeed = 0.1f;

    public float jumpCooldown = 2f;
    public bool isFacingRight = true;

    private float lastJumpTime = 0;


    public float jumpWindUp = 1f;
    public float jumpSpeed = 100f;
    public float landingDuration = 1f;

    private bool isMidJump=false;

    // Start is called before the first frame update

    IEnumerator jumpCorutine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMidJump) transform.position += new Vector3(movementSpeed * (isFacingRight?1:-1), 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) {
            isFacingRight = !isFacingRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CatJumpPoint") && Time.time-lastJumpTime>jumpCooldown) {
            Debug.Log("Cat found a jump point");
            float prob = collision.GetComponent<CatJumpPoint>().jumpProbability;
            float roll = Random.Range(0f, 1f);
            Debug.Log("Roll: "+roll+" need to beat "+ prob);
            if (roll < prob) {
                jumpCorutine = Jump(collision.GetComponent<CatJumpPoint>().jumpDestination);
                Debug.Log("Jumping");
                StartCoroutine(jumpCorutine);
                lastJumpTime = Time.time;
            }
        }
    }

    private IEnumerator Jump(GameObject jumpDestination)
    {
        Debug.Log("JumpCorutine starterd");
        isMidJump = true;
        yield return new WaitForSeconds(jumpWindUp);

        while (!transform.position.Equals(jumpDestination.transform.position)) {
            Debug.Log("JumpLoop");

            transform.position = Vector3.MoveTowards(transform.position, jumpDestination.transform.position, jumpSpeed);
            yield return null;
        }
        yield return new WaitForSeconds(landingDuration);
        isMidJump =false;
       
    }
}
