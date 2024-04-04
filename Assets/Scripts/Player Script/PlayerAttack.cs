using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombiState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_anim;
    private bool activateTimerToReset;
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private CombiState current_Combo_State;

    void Awake()
    {
        player_anim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Start() {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = CombiState.NONE;
    }
    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if(current_Combo_State == CombiState.PUNCH_3 || 
            current_Combo_State == CombiState.KICK_1 || 
            current_Combo_State == CombiState.KICK_2)
            return;
        if(Input.GetKeyDown(KeyCode.Z))
        {
            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == CombiState.PUNCH_1)
                player_anim.Punch1();
            if(current_Combo_State == CombiState.PUNCH_2)
                player_anim.Punch2();
            if(current_Combo_State == CombiState.PUNCH_3)
                player_anim.Punch3();

        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            // If the current combo state is Punch_3 or Kick_2 the return
            //  Because we dont have any other combos to perform
            if(current_Combo_State == CombiState.PUNCH_3 ||
                current_Combo_State == CombiState.KICK_2)
                return;

            // If the current combo state is None or Punch_1 or Punch_2 
            // then we can set current combo state to Kick_1 and we can perform punch kick combo
            if(current_Combo_State == CombiState.NONE ||
                current_Combo_State == CombiState.PUNCH_2 ||
                current_Combo_State == CombiState.PUNCH_1)
            {
                current_Combo_State = CombiState.KICK_1;
            }
            else if(current_Combo_State == CombiState.KICK_1)
            {
                current_Combo_State++;
            }

            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == CombiState.KICK_1)
                player_anim.Kick1();
            if(current_Combo_State == CombiState.KICK_2)
                player_anim.Kick2();
        }
    }

    void ResetComboState()
        {
            if(activateTimerToReset)
            {
                current_Combo_Timer -= Time.deltaTime;
                if(current_Combo_Timer <= 0f)
                {
                    current_Combo_State = CombiState.NONE;
                    activateTimerToReset = false;
                    current_Combo_Timer = default_Combo_Timer;
                }
            }
        }
}
