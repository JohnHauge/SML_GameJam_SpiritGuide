using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public bool dead = false;
    public bool shielded = false;
    private HingeJoint2D joint;

    private int bodyPartyHP = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision) {

        print(collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > 2.5 && 
            collision.relativeVelocity.magnitude < 3.8){
            bodyPartyHP--;

            if (bodyPartyHP <= 0){
                Destroy(gameObject.GetComponent(typeof(HingeJoint2D)) as HingeJoint2D);
            }
            return;
        }

        if (collision.relativeVelocity.magnitude > 3.8 && !shielded){
            dead = true;
            Destroy(gameObject.GetComponent(typeof(HingeJoint2D)) as HingeJoint2D);
            //print("SPLAT!!!" + collision.relativeVelocity.magnitude);
        }
    }


}
