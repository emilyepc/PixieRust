using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorBits : MonoBehaviour
{
    public Animator animator;
    public bool isTriggerParticleActive = false; 

    
    public void ActivateTriggerParticle()
    {
        animator.SetBool("isTriggerParticleActive", true);
        Debug.Log("Particle active");
    }

    
    public void DeactivateTriggerParticle()
    {
        animator.SetBool("isTriggerParticleActive", false);
    }

   
    public void TriggerParticle()
    {
        animator.Play("metarig | metarigAction");
    }
}
