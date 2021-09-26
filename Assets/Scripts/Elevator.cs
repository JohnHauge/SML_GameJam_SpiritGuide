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

        toPos.gameObject.SetActive(false);

        //Remove This
        //Invoke("StartElevator", 2f);
    }

    public void StartElevator(){
        if (isActive) return;

        StartCoroutine(elevatorRoutine());
    }

    private IEnumerator elevatorRoutine(){
        
        isActive = true;
        var t = 0f;
        bool goingTo = false;

        while(t < elevatorTravelTime && !goingTo){
            t += Time.fixedDeltaTime;

            var lerp = Mathf.InverseLerp(0f, elevatorTravelTime, t);

            elevatorRB.MovePosition(Vector2.Lerp(_fromPos, _toPos,lerp));

            yield return new WaitForFixedUpdate();
        }

        goingTo = true;
        t = 0f;

        yield return new WaitForSeconds(elevatorPauseTime);

            while(t < elevatorTravelTime && goingTo){

            t += Time.fixedDeltaTime;

            var lerp = Mathf.InverseLerp(0f, elevatorTravelTime, t);

            elevatorRB.MovePosition(Vector2.Lerp(_toPos,_fromPos,lerp));

            yield return new WaitForFixedUpdate();
        }

        isActive = false;

        yield return null;
    }

}
