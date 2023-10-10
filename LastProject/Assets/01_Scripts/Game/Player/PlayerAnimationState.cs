using UnityEngine;

public class PlayerAnimationState : MonoBehaviour
{
    string currentState;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimationState("player_DownIdle");
    }

    public void ChangeAnimationState(string newState)
    {
        // Stop the same animation from interrupting itself
        if (currentState == newState)
        {
            //Debug.Log("currentState == newState");
            return;
        }

        // Play the animation
        animator.Play(newState);

        // Reassign the current state
        currentState = newState;
    }

    void Update()
    {       
        bool up = Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);

        if (Input.GetKeyUp(KeyCode.W))
        {
            ChangeAnimationState("Player_UpIdle");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            ChangeAnimationState("Player_DownIdle");
        }
        if (up)
        {
            if (left) ChangeAnimationState("Player_LeftUp");
            else if (right) ChangeAnimationState("Player_RightUp");
            else  ChangeAnimationState("Player_Up");
            
        }       
        else if (down)
        {
            if (left) ChangeAnimationState("Player_LeftDown");
            else if (right) ChangeAnimationState("Player_RightDown");
            else ChangeAnimationState("Player_DownWalk");
        }
        else if (left) ChangeAnimationState("Player_Left");
        else if (right) ChangeAnimationState("Player_Right");

    }
}
