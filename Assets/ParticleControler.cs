using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControler : MonoBehaviour
{

    //[SerializeField] ParticleSystem movementParticle;

    //[Range(0, 0.1f)]
    //[SerializeField] float occurAfterVelocity;

    //[Range(0, 0.2f)]
    //[SerializeField] float dustFormationPeriod;

    //[SerializeField] Rigidbody2D playerRb;

    //float counter;

    //void Update()
    //{
    //    counter += Time.deltaTime;

    //    if (playerRb.velocity.magnitude > occurAfterVelocity)
    //    {
    //        if (counter > dustFormationPeriod)
    //        {
    //            movementParticle.Play();
    //            counter = 0;
    //        }
    //    }
    //}
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] Transform particleTransform;
    [SerializeField] float particleYUpOffset;
    [SerializeField] float particleYDownOffset;
    [SerializeField] float particleXLeftOffset;
    [SerializeField] float particleXRightOffset;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float dustFormationPeriod;

    float counter;

    void Update()
    {
        if (Mathf.Abs(playerRb.velocity.x) > 0 )
        {
            counter += Time.deltaTime;
            if (counter >= dustFormationPeriod)
            {
                if (!movementParticle.isPlaying)
                {
                    movementParticle.Play();
                }
                if (playerRb.velocity.x > 0)
                {
                    particleTransform.localPosition = new Vector3(particleXLeftOffset, 0, 0);
                }
                else if (playerRb.velocity.x < 0)
                {
                    particleTransform.localPosition = new Vector3(particleXRightOffset, 0, 0);
                }
                
                counter = 0f;
            }
        }
        else
        {
            movementParticle.Stop();
            counter = 0f;
        }
    }


}
