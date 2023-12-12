using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTrigger : MonoBehaviour
{
    public EnemyAi enemyAi;
    private Animator mAnimator;
    public bool GetHit = false;


    public State state;
    public enum State
    {
        Idle,
        Approaching,
        Attacking,
        Hit
    }
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                mAnimator.SetBool("isIdle", true);
                mAnimator.SetBool("isApproaching", false);
                mAnimator.SetBool("isAttacking", false);
                break;
            case State.Approaching:
                // Debug.Log("Search for the player");
                break;
            case State.Attacking:
                // Debug.Log("Attack the player");
                break;
        }
        
        bool Walktrigger = mAnimator.GetBool("Walktrigger");
        bool Approaching = enemyAi.isApproaching;

        // bool OutOfSightTrigger = mAnimator.GetBool("OutOfSightTrigger");
        // bool Patroll = enemyAi.isPatroling;

        bool InAttackRange = mAnimator.GetBool("InAttackRange");
        bool Attacking = enemyAi.isAttacking;

        if (mAnimator != null)
        {           
            if (Approaching)
            {
                mAnimator.SetBool("Walktrigger", true);
            }
            if (!Approaching)
            {
                mAnimator.SetBool("Walktrigger", false);
            }

            // if (!OutOfSightTrigger && Patroll)
            // {
            //     mAnimator.SetBool("OutOfSightTrigger", true);
            // }
            // if (OutOfSightTrigger && !Patroll)
            // {
            //     mAnimator.SetBool("OutOfSightTrigger", false);
            // }


            if (!InAttackRange && Attacking)
            {
                mAnimator.SetBool("InAttackRange", true);
            }
            if (InAttackRange && !Attacking)
            {
                mAnimator.SetTrigger("InAttackRange");
            }

            if (GetHit)
            {
                mAnimator.SetTrigger("Hit");

                // Debug.Log("Hit walktrigger");

            }

            GetHit = false;

        }
    }
}
