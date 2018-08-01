using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : StateMachineBehaviour {
    [SerializeField]
    private float reloadTime = 0.7f;
    private bool hasReloaded = false;
   // public GameObject player;
    //private WeaponManager wm;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        hasReloaded = false;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (hasReloaded) return;

       // wm = player.GetComponent<WeaponManager>();
        //Animator anim;
        /*int index;
        if (BulletsController.instance.activeWeapon == 2)
        {
            index = 1;
        }*/
        

        if (stateInfo.normalizedTime >= reloadTime)
        {

            //anim = wm.weaponsInUse[1].GetComponent<Animator>();
            //anim.GetComponent<Weapon>().Reload();
            animator.GetComponent<Weapon>().Reload();
            hasReloaded = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasReloaded = false;
    }
    
	
	

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
