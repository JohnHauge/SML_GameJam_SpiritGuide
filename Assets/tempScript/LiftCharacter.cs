using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCharacter : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.freezeRotation = true;
    }

    private void Update() {
        rigidbody2D.velocity = new Vector2(0f, 1f);
        
    }

}
