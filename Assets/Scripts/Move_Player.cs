using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float speed_Move = 3f;
    [SerializeField] private float player_Jump = 2f;
    [SerializeField] private float gravity = 0.05f;
    [SerializeField] float speed_MoveCurrent;
    [SerializeField] float speed_Defolt = 0f;
    [SerializeField] float speed_Run = 7f;  
    [SerializeField] private CharacterController player;
    [SerializeField] float maxSpeed = 7f;
    Vector3 move_Direction;
    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<CharacterController>();     
    }
    private void Update()
    {
    
        player_Move();
        
    }

    private void player_Move()
    {

        float x_Move = Input.GetAxis("Horizontal");
        float z_Move = Input.GetAxis("Vertical");


        if (player.isGrounded)
        {
            move_Direction = new Vector3(x_Move, 0f, z_Move);
            move_Direction = transform.TransformDirection(move_Direction);


            if (Input.GetKey(KeyCode.Space))
            {
                move_Direction.y += player_Jump;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                player.height = 1.25f;
            }
            else 
            { 
                player.height = 1.5f; 
            }
            
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) 
        {
            speed_MoveCurrent = Mathf.Lerp(speed_MoveCurrent,maxSpeed,Time.deltaTime*2);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            speed_MoveCurrent = Mathf.Lerp(speed_MoveCurrent, speed_Move, Time.deltaTime * 2);
        }
        else
        {
            speed_MoveCurrent = Mathf.Lerp(speed_MoveCurrent, speed_Defolt, Time.deltaTime * 2);
        }
        move_Direction.y -= gravity;
      
        player.Move(move_Direction* speed_MoveCurrent * Time.deltaTime);
        
        animator.SetFloat("Speed", speed_MoveCurrent);

    }
  
}
