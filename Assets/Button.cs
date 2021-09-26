using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public bool pressed;
    //private float timer;
    private Ghost ghost;
    private Collider2D trigger;
    private SpriteRenderer renderer;  
    private UnityEvent startEvent;
    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent(typeof(Collider2D)) as Collider2D;
        renderer = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        startEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update(){}

    void OnTriggerEnter2D(Collider2D col){
        ghost = col.gameObject.GetComponent(typeof(Ghost)) as Ghost;
        print(col.name);
        if (ghost.powerup == 1 && !pressed){
            pressed = true;
            //renderer.color = new Color(254, 116, 54);
            renderer.color = Color.green;
            ghost.powerup = 0;
            startEvent.Invoke();
        }
    }
}
