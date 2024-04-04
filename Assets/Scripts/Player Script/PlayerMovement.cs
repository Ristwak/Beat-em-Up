using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody rb;
    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;
    private float rotation_Y = -90f;
    private float rotation_speed = 15f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    private void FixedUpdate() {
        DetectMovement();
    }
    
    void DetectMovement()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)*(-walk_Speed),rb.velocity.y,Input.GetAxisRaw(Axis.VERTICAL_AXIS)*(-z_Speed));
    }

    void RotatePlayer()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f,rotation_Y,0f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_Y),0f);
        }
    }
    
    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
            player_Anim.Walk(true);
        else
            player_Anim.Walk(false);
    }
}
