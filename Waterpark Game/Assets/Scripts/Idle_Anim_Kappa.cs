using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Anim_Kappa : StateMachineBehaviour
{
    public int ClipCount = 3;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Idlerandom", Random.Range(0, ClipCount));
    }
}
