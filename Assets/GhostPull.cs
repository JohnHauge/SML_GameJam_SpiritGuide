using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPull : MonoBehaviour
{
    private Ghost ghost;
    private Vector2 ghostPos;
    private Rigidbody2D ghostBody;
    private Vector2 pos;
    private Rigidbody2D target;
    private Vector2 direction;
    private float force;
    private float magnitude;
    private Collider2D hitBox;
    private Collider2D targetCollider;
    // Start is called before the first frame update
    void Start()
    {
        hitBox = GameObject.Find("hitBox").GetComponent(typeof(Collider2D)) as Collider2D;
        ghost = GameObject.FindWithTag("Player").GetComponent(typeof(Ghost)) as Ghost;
        ghostBody = ghost.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        target = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        targetCollider = gameObject.GetComponent(typeof(Collider2D)) as Collider2D;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitBox.IsTouching(targetCollider) && ghost.GetEnergy() > 0){
            pos = target.position;
            ghostPos = ghostBody.position;
            direction = ghostPos - pos;
            magnitude = direction.magnitude;
            if (magnitude < 4){
                force = ghost.strength/(magnitude*magnitude + 2) ;
                target.AddForce(direction.normalized * force);
                ghost.SetEnergy(ghost.GetEnergy() - Time.deltaTime);
                print("Energy = " + ghost.GetEnergy());
            }else
            {
                ghost.stopDraining();
            }
        } else
        {
            ghost.stopDraining();
        }
    }
}
