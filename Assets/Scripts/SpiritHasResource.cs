using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritHasResource : MonoBehaviour
{
    private Ghost ghost;

    [SerializeField] private ParticleSystem ResourceParticleSystem;

    private void Awake() {
        ghost = GetComponent<Ghost>();
    }

    private void Update() {
        if(ghost.powerup > 0 && ResourceParticleSystem.isStopped)
        {
            ResourceParticleSystem.Play();
        }
        else if (ghost.powerup <= 0 && ResourceParticleSystem.isPlaying)
        {
            ResourceParticleSystem.Stop();
        }
    }
}
