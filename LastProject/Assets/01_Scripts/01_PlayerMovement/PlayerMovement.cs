using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    float playerSpeed;//10

    [SerializeField]
    Vector2 inputVec;

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");       
    }

    void FixedUpdate()
    {
        Vector2 nextVec = playerSpeed * Time.fixedDeltaTime * inputVec.normalized;
        rigid.MovePosition(rigid.position + nextVec);
    }
}
