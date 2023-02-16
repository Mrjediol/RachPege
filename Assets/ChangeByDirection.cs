using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeByDirection : StateMachineBehaviour
{
    //[SerializeField]
    //public Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //[SerializeField]
    //public AnimationDictionary animationDictionary = new AnimationDictionary();
    //[System.Serializable]
    //public class AnimationDictionary
    //{
    //    public Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
    //}

    [Tooltip("0 R, 1 L, 2 U, 3 D")]
    public AnimationClip[] animations = new AnimationClip[4];


    LookPlayer lookPlayer;

    private AnimatorOverrideController overrideController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lookPlayer = animator.GetComponent<LookPlayer>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Animation animation = animations[lookPlayer.desiredDirection];

        // Obtener el clip actual del estado
        var currentClip = animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip;

        // Llamar a la función pasando el clip actual como parámetro
        AnimationClip animation = animations[lookPlayer.desiredDirection];
        //currentClip.motion = animation;

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
