using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector2 moveInput;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        rb2d.linearVelocity = moveInput * moveSpeed;
    }
}
