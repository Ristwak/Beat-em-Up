using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT,move);
    }

    public void Punch1()
    {
        anim.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }

    public void Punch2()
    {
        anim.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }

    public void Punch3()
    {
        anim.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }

    public void Kick1()
    {
        anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick2()
    {
        anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    public void Death()
    {
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
    
    
    // Enemy Animation
    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger(AnimationTags.Attack_1_Trigger);
        }
        if(attack == 1)
        {
            anim.SetTrigger(AnimationTags.Attack_2_Trigger);
        }
        if(attack == 2)
        {
            anim.SetTrigger(AnimationTags.Attack_3_Trigger);
        }
    }

    public void PlayIdleAnimation()
    {
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }
    
    public void KnockDown()
    {
        anim.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }
    public void StandUp()
    {
        anim.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }
    
    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void EnemyDeath()
    {
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
}
