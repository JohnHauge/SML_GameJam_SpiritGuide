using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayPause : MonoBehaviour
{
   [SerializeField] private ParticleSystem particleSystem;

   public void playParticleSystem( ){
       particleSystem.Play();
   }

   public void PauseParticleSystem(){
       particleSystem.Stop();
   }
}
