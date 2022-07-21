using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int powerup = 1;
    public float respawn = 5.0f;
    private float timer;
    private Ghost ghost;
    private Collider2D trigger;
    //private SpriteRenderer renderer;

    [SerializeField] private GameObject ToTurnOff;

    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent(typeof(Collider2D)) as Collider2D;
        //renderer = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        timer = respawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trigger.enabled)
        {
            timer -= Time.deltaTime;
            if (timer <= 0){
                trigger.enabled = true;
                //renderer.enabled = true;
                ToTurnOff.SetActive(true);
                timer = respawn;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        ghost = col.gameObject.GetComponent(typeof(Ghost)) as Ghost;
        ghost.setPowerupState(powerup);
        trigger.enabled = false;
        //renderer.enabled = false;
        ToTurnOff.SetActive(false);
    }
}
