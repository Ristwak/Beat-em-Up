using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;
    
    public bool is_Player, is_Enemy;

    public GameObject hit_FX_Prefab;

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitfX_Pos = hit[0].transform.position;
                hitfX_Pos.y += 1.3f;

                if (hit[0].transform.position.x > 0)
                {
                    hitfX_Pos.x += 0.3f;
                }
                else if (hit[0].transform.position.x < 0)
                {
                    hitfX_Pos.x -= 0.3f;
                }

                Instantiate(hit_FX_Prefab, hitfX_Pos, Quaternion.identity);

                if(gameObject.tag == Tags.LEFT_ARM_TAG || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }

            if(is_Enemy)
            {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }
            gameObject.SetActive(false);
        }
    }
}
