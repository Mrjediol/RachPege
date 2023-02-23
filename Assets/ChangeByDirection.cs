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

    [Tooltip("0 R, 1 U, 2 D,")]
    public AnimationClip[] animations = new AnimationClip[4];




    private AnimatorOverrideController overrideController;
    private LookPlayer lookPlayer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        lookPlayer = animator.GetComponent<LookPlayer>();

        // Create a new AnimatorOverrideController based on the current controller


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);

        // Assign the override controller to the Animator
        animator.runtimeAnimatorController = overrideController;


        var currentClip = animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip;

        // Determine the desired direction of movement
        int direction = lookPlayer.desiredDirection;
        // Check that the desired direction is within the range of valid indices
        if (direction >= 0 && direction < animations.Length && animations[direction] != null)
        {
            // Override the current clip with the desired clip for the given direction

            overrideController[currentClip] = animations[direction];
            animator.runtimeAnimatorController = overrideController;
            //var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>(overrideController.overridesCount);
            //overrideController.GetOverrides(overrides);
            //overrideController.ApplyOverrides(overrides);
        }

    }

        

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}


//Animation animation = animations[lookPlayer.desiredDirection];

// Obtener el clip actual del estado
//var currentClip = animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip;

//// Llamar a la función pasando el clip actual como parámetro
//AnimationClip animation = animations[lookPlayer.desiredDirection];
//currentClip.motion = animation;
// Obtener el clip actual del estado

// Obtener el nuevo clip que deseas asignar a la animación
//AnimationClip animation = animations[lookPlayer.desiredDirection];

// Crear un AnimatorOverrideController a partir del controlador actual del Animator
//if (overrideController == null )
//{
//    overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
//}

//// Asignar el nuevo clip al clip actual en el AnimatorOverrideController
//overrideController[currentClip] = animation;

//// Asignar el AnimatorOverrideController al Animator
//animator.runtimeAnimatorController = overrideController;