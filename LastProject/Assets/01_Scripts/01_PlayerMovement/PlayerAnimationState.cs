using UnityEngine;

public class PlayerAnimationState : MonoBehaviour
{
    static string currentState;
    static Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = "player_Idle";
    }

    public static void ChangeAnimationState(string newState)
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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            PlayerAnimationState.ChangeAnimationState("Player_RightUp");
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            PlayerAnimationState.ChangeAnimationState("Player_LeftUp");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            PlayerAnimationState.ChangeAnimationState("Player_Up");
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            PlayerAnimationState.ChangeAnimationState("Player_RightDown");
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            PlayerAnimationState.ChangeAnimationState("Player_LeftDown");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerAnimationState.ChangeAnimationState("Player_Down");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerAnimationState.ChangeAnimationState("Player_Right");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerAnimationState.ChangeAnimationState("Player_Left");
        }
        else
        {
            PlayerAnimationState.ChangeAnimationState("Player_Idle");
        }
    }
}
