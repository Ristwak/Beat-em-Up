using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation EnemyAnim;
    private Rigidbody rb;
    public float Enmspeed = 1.8f;
    private Transform playerTarget;
    public float attack_Distance = 1.3f;
    public float chase_Player_After_Attack = 1f;
    private float current_Attack_Time;
    private float default_Attack_Time = 2f;

    private bool followPlayer , attackPlayer ;

    void Awake()
    {
        EnemyAnim = GetComponentInChildren<CharacterAnimation>();
        rb = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start() {
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }
    
    private void FixedUpdate() {
        Followtarget();
    }
    void Update()
    {
        Attack();
    }
    void Followtarget()
    {
        if(!followPlayer)
            return;

        if(Vector3.Distance(transform.position,playerTarget.position) > attack_Distance)
        {
            transform.LookAt(playerTarget);
            rb.velocity = transform.forward * Enmspeed;

            if(rb.velocity.sqrMagnitude != 0)
            {
                EnemyAnim.Walk(true);
            }
        }
        else if(Vector3.Distance(transform.position,playerTarget.position) <= attack_Distance)
        {
            rb.velocity = Vector3.zero;
            EnemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }
    
    void Attack()
    {
        if(!attackPlayer)
            return;
        
        current_Attack_Time += Time.deltaTime;

        if(current_Attack_Time > default_Attack_Time)
        {
            EnemyAnim.EnemyAttack(Random.Range(0,3));
            current_Attack_Time = 0f;
        }

        if(Vector3.Distance(transform.position,playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
