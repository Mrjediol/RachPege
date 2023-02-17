using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public Animator animator;
    public LookPlayer lookPlayer;
    public AnimationClip[] animations;
    public AnimatorOverrideController overrideController;

    void Update()
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        OnStateUpdate(animator, stateInfo, 0);
    }

    public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var currentClip = animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip;

        // Determine the desired direction of movement
        int direction = lookPlayer.desiredDirection;

        // Check that the desired direction is within the range of valid indices
        if (direction >= 0 && direction < animations.Length && animations[direction] != null)
        {
            // Override the current clip with the desired clip for the given direction
            overrideController[currentClip] = animations[direction];
            animator.runtimeAnimatorController = overrideController;
        }
    }
}
