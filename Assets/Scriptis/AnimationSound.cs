using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private Animator anim;
    private bool hasPlayedSound;

    public void PlayAnimation(string animation)
    {
        if (!hasPlayedSound)
        {
            soundEffect.Play();
            hasPlayedSound = true;
        }
        anim.Play(animation);
    }

    public void OnAnimationEnd()
    {
        hasPlayedSound = false;
    }
}