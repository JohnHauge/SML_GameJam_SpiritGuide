using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 8.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float horizontal;
    private float vertical;
    private float energy;
    private bool draining;
    private bool exhausted;
    public float maxEnergy = 2f;
    public float strength = 40f;
    

    private void Start()
    {
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
    }

    public void SetEnergy(float f){energy = f;}
    public float GetEnergy(){
        draining = true;
        return energy;
    }

    public void stopDraining(){
        draining = false;
        }

    public bool GetExhausted(){return exhausted;}

    public void exhaust(){exhausted = true;}

}