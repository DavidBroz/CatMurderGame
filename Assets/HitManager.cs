using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    public float knockbackForce = 100;
    public float knockbakHeight = 1;
    public float hitCooldown = 1f;
    public float stunDuration = 0.5f;

   

    private float lastHitTime = 0;

    IEnumerator stunCorutine;
    public void TakeHit(GameObject hittingGameObject) {
        //Destroy(this.gameObject);
        if (Time.time - lastHitTime > hitCooldown)
        {
            Vector3 dir = (this.transform.position - hittingGameObject.transform.position).normalized;
            dir.y = knockbakHeight;
            GetComponent<Rigidbody2D>().AddForce(dir * knockbackForce);

            stunCorutine = StunCorutine(stunDuration);
            StartCoroutine(stunCorutine);
            Debug.Log("Auch! " + this.gameObject.name + " got hit!");
            
        }
    }

    IEnumerator StunCorutine(float stunDuration) { 
        GetComponent<MouseController>().stunned = true;
        yield return new WaitForSeconds(stunDuration);
        GetComponent<MouseController>().stunned = false;
    }
}
