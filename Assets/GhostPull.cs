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
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("Ghost").GetComponent(typeof(Ghost)) as Ghost;
        ghostBody = ghost.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        target = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && ghost.GetEnergy() > 0){
            pos = target.position;
            ghostPos = ghostBody.position;
            direction = ghostPos - pos;
            magnitude = direction.magnitude;
            if (magnitude < 4){
                force = ghost.strength/(magnitude + 2) ;
                target.velocity = target.velocity + direction.normalized * force * Time.deltaTime;
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
