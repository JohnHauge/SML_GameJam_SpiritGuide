using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPull : MonoBehaviour
{
    private static GameObject currentGameObject;
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
        ghost = GameObject.FindWithTag("Player").GetComponent(typeof(Ghost)) as Ghost;
        ghostBody = ghost.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        target = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        targetCollider = gameObject.GetComponent(typeof(Collider2D)) as Collider2D;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGameObject != null && currentGameObject != gameObject) return;

                hitBox = GameObject.Find("hitBox").GetComponent(typeof(Collider2D)) as Collider2D; 

        if (hitBox.IsTouching(targetCollider) && ghost.GetEnergy() > 0){
            currentGameObject = gameObject;
            pos = target.position;
            ghostPos = ghostBody.position;
            Vector2 cursorPos = ghost.puller.transform.position;
            direction = cursorPos - pos;
            magnitude = direction.magnitude;
            if (magnitude < 4){
                
                force = (ghost.strength/(magnitude*magnitude + 2))*Time.deltaTime;
                print(force);
                target.AddForce(direction.normalized * force);
                ghost.SetEnergy(ghost.GetEnergy() - Time.deltaTime);
                print("Energy = " + ghost.GetEnergy());
            }else
            {
                ghost.stopDraining();
            }
        } else
        {
            currentGameObject = null;
            ghost.stopDraining();
        }
    }
}
