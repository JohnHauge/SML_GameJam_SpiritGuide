using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonReuseable : MonoBehaviour
{
    public bool pressed;
    //private float timer;
    private Ghost ghost;
    private Collider2D trigger;
    private SpriteRenderer renderer;  
    private Color basecolor;
    public float delay;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent(typeof(Collider2D)) as Collider2D;
        renderer = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        basecolor = renderer.color;
    }

    // Update is called once per frame
    void Update(){
        if(pressed)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
            pressed = false;
            renderer.color = basecolor;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        ghost = col.gameObject.GetComponent(typeof(Ghost)) as Ghost;
        print(col.name);
        if (ghost.powerup == 1 && !pressed){
            pressed = true;
            //renderer.color = new Color(254, 116, 54);
            renderer.color = Color.green;
            ghost.powerup = 0;
            timer = delay;
            (gameObject.GetComponent(typeof(EventTrigger)) as EventTrigger).StartTheEvent();
        }
    }
}
