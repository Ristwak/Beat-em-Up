using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject Left_Arm_Attack_Point,Right_Arm_Attack_Point,Left_Leg_Attack_Point,Right_Leg_Attack_Point;

    public float stand_Up_Timer = 2f;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_Sound,fall_Sound,ground_hit_Sound,dead_Sound;

    private EnemyMovement enemyMovement;

    private Shakecamera shakeCamera; 

    private void Awake() {
        animationScript = GetComponent<CharacterAnimation>();

        audioSource = GetComponent<AudioSource>();

        if(gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }

        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<Shakecamera>();
    }
    
    // Left Arm
    void Left_Arm_Attack_On()
    {
        Left_Arm_Attack_Point.SetActive(true);
    }
    void Left_Arm_Attack_Off()
    {
        if(Left_Arm_Attack_Point.activeInHierarchy)
        {
            Left_Arm_Attack_Point.SetActive(false);
        }
    }

    // Right Arm
    void Right_Arm_Attack_On()
    {
        Right_Arm_Attack_Point.SetActive(true);
    }
    void Right_Arm_Attack_Off()
    {
        if(Right_Arm_Attack_Point.activeInHierarchy)
        {
            Right_Arm_Attack_Point.SetActive(false);
        }
    }


    // Left Leg
    void Left_Leg_Attack_On()
    {
        Left_Leg_Attack_Point.SetActive(true);
    }
    void Left_Leg_Attack_Off()
    {
        if(Left_Leg_Attack_Point.activeInHierarchy)
        {
            Left_Leg_Attack_Point.SetActive(false);
        }
    }

    // Right Leg
    void Right_Leg_Attack_On()
    {
        Right_Leg_Attack_Point.SetActive(true);
    }
    void Right_Leg_Attack_Off()
    {
        if(Right_Leg_Attack_Point.activeInHierarchy)
        {
            Right_Leg_Attack_Point.SetActive(false);
        }
    }

    void TagLeft_Arm()
    {
        Left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeft_Arm()
    {
        Left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeft_Leg()
    {
        Left_Leg_Attack_Point.tag = Tags.LEFT_LEG_TAG;
    }

    void UnTagLeft_Leg()
    {
        Left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAferTime());
    }

    IEnumerator StandUpAferTime()
    {
        yield return new WaitForSeconds(stand_Up_Timer);
        animationScript.StandUp();
    }

    public void Attack_FX_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh_Sound;
        audioSource.Play();
    }

    public void Character_Died_Sound()
    {
        audioSource.volume = 1f;
        audioSource.clip = dead_Sound;
        audioSource.Play();
    }

    public void Enemy_KnockDown()
    {
        audioSource.clip = fall_Sound;
        audioSource.Play();
    }

    public void Enemy_HitGround()
    {
        audioSource.clip = ground_hit_Sound;
        audioSource.Play();
    }

    void DisableMovement()
    {
        enemyMovement.enabled = false;

        // set the enemy layer to default so that player wouldnt be able to hit the enemy while he's falling or is laying on the groound
        transform.parent.gameObject.layer = 0;
    }

    void EnableMovement()
    {
        enemyMovement.enabled = true;

        // set the enemy layer to Enemy so that player will be able to hit the enemy as soon as he stands up
        transform.parent.gameObject.layer = 7;
    }

    void ShakecameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    void CharacterDied()
    {
        Invoke("DeactivateGameObject",2f);
    }

    void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();

        gameObject.SetActive(false);
    }
}
