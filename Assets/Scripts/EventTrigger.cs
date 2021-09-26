using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour {
    
    public UnityEvent startEvent;

    public void StartTheEvent(){
        startEvent.Invoke();
    }

}