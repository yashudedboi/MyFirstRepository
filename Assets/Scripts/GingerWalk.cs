using UnityEngine;

public class GingerWalk : MonoBehaviour
{
    public float walkSpeed;
    public Rigidbody gingerRb;

    // Update is called once per frame
    public void Update()
    {
        gingerRb.linearVelocity = Vector3.zero;

        Vector3 moveDirection = GetMoveDirection();

        transform.Translate(moveDirection * walkSpeed * Time.deltaTime);
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }

        moveDirection = moveDirection.normalized;

        return moveDirection;
    }
}
