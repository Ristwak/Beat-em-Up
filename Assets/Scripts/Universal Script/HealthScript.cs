using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    public EnemyMovement enemyMovement;

    public GameObject EndGameMenuUi;

    private bool characterDied;

    public bool is_Player;

    private HealthUI healthUI;

    private void Awake() {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        if(isActiveAndEnabled)
        {
            healthUI = GetComponent<HealthUI>();
        }
    }
    public void ApplyDamage(float damage , bool knockDown)
    {
        if(characterDied)
            return;
        
        health -= damage;

        if(is_Player)
        {
            healthUI.DisplayHealth(health);
        }

        if(health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

            if(is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponentInParent<EnemyMovement>().enabled = false;
                EndGameMenuUi.SetActive(true);
            }
            return;
        }

        if(!is_Player)
        {
            if(knockDown)
            {
                if(Random.Range(0,2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if(Random.Range(0,3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
    }
}
