using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform toPos;
    [SerializeField] private Rigidbody2D elevatorRB;
    private Vector2 _fromPos;
    private Vector2 _toPos;

    [SerializeField] private float elevatorTravelTime;
    [SerializeField] private float elevatorPauseTime;

    private bool isActive = false;

    private void Awake() {
        _fromPos = elevatorRB.transform.position;
        _toPos = toPos.position;
    }

    private void StartElevator(){
        if (isActive) return;

        StartCoroutine(elevatorRoutine());
    }

    private IEnumerator elevatorRoutine(){
        
        var t = 0f;
        bool goingTo = false;

        while(t < elevatorTravelTime){
            
        }

        yield return null;
    }

}
