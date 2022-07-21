using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GambleBassenFollowGround : MonoBehaviour
{
    private Rigidbody2D theRB;

    public float maxRayDistance;
    public float offset;

    private void Start() {
        theRB = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        
        int layermask = 1 << 8;
        layermask = ~layermask;
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, Vector2.down, maxRayDistance, layermask);

        if(hit2d){
            Vector2 NewPosition = new Vector2(theRB.position.x, hit2d.point.y + offset);
            theRB.MovePosition(NewPosition);
        }

    }
}
