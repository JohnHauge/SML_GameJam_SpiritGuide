using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 1.0f;
    private float horizontal;
    private float vertical;
    private float energy;
    private bool draining;
    private bool exhausted;
    public CircleCollider2D puller;
    public float maxEnergy;
    public float strength;
    public int powerup;
    

    private void Start()
    {
        puller = new GameObject("hitBox", typeof(CircleCollider2D)).GetComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        puller.radius = 0.2f;
        puller.isTrigger = true;
        body = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        energy = maxEnergy;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        
        if (move != Vector2.zero)
        {           
            body.velocity = move * playerSpeed;
        }
        if (!draining && energy < maxEnergy) energy += Time.deltaTime;

        if(Input.GetButton("Fire1"))
        {
            print(puller.enabled);
            if(!puller.enabled && energy > 0.5)
            {
                puller.enabled = true;
            } else if(energy <= 0){puller.enabled = false;
            } else if(puller.enabled){
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0;
                puller.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            }


        } else {puller.enabled = false;}
    }

    public void SetEnergy(float f){energy = f;}
    public float GetEnergy(){
        draining = true;
        return energy;
    }

    public void stopDraining(){
        draining = false;
        }

    public void setPowerupState(int state){
        powerup = state;
        print("Powerup: " + powerup);
    }
}