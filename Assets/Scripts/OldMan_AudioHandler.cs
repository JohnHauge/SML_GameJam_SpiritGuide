using UnityEngine;

public class OldMan_AudioHandler : MonoBehaviour {
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform theBody;

    [Tooltip("From where does the audio start to fade in?")]
    [SerializeField] private float distanceFromBody;

    private Transform oldMan;

    private float volumeLerp;


    private void Awake() {
        oldMan = transform;
    }

    private void FixedUpdate() {
        // not optimal but gameJam
        var currentdistanceFromBody = Vector2.Distance(oldMan.position, theBody.position);

        if(distanceFromBody > 10f){
            audioSource.volume = 0f;
            return;
        }

        volumeLerp = Mathf.InverseLerp(distanceFromBody, 0f, currentdistanceFromBody);

        audioSource.volume = volumeLerp;
    }
}