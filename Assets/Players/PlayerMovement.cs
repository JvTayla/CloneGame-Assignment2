using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    [Header("Input (assign per player)")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    [Header("Movement")]
    public float moveSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 12f;       //full-press jump velocity
    [Range(0.1f, 1f)]
    public float jumpCutMultiplier = 0.5f; //how much to cut when releasing early
    public float gravityScale = 3f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    [Header("Sound Effects")]
    public AudioSource deathSound;
    public AudioSource jumpSound;

    private Animator _animator;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded;

    private Vector3 respawnPoint;
    public string playerTag;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    private void Start()
    {
        respawnPoint = transform.position;

        _animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        if (moveAction != null)
        {
            moveAction.action.performed += OnMovePerformed;
            moveAction.action.canceled += OnMoveCanceled;
            moveAction.action.Enable();
        }

        if (jumpAction != null)
        {
            jumpAction.action.started += OnJumpStarted;
            jumpAction.action.canceled += OnJumpCanceled;
            jumpAction.action.Enable();
        }
    }

    void OnDisable()
    {
        if (moveAction != null)
        {
            moveAction.action.performed -= OnMovePerformed;
            moveAction.action.canceled -= OnMoveCanceled;
            moveAction.action.Disable();
        }

        if (jumpAction != null)
        {
            jumpAction.action.started -= OnJumpStarted;
            jumpAction.action.canceled -= OnJumpCanceled;
            jumpAction.action.Disable();
        }
    }

    void Update()
    {
        if (groundCheck != null)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        _animator.SetFloat("Speed", Mathf.Abs(moveInput.x));

        if (moveInput.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1); // facing right
        }
        else if (moveInput.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1); // facing left
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    private void OnJumpStarted(InputAction.CallbackContext ctx)
    {
        if (isGrounded)
        {
            var v = rb.velocity;
            v.y = jumpForce;
            rb.velocity = v;

            _animator.SetBool("isJumping", !isGrounded);
            jumpSound.Play();
        }

        
    }

    private void OnJumpCanceled(InputAction.CallbackContext ctx)
    {
        //variable jump height: cut upward velocity when release early
        if (rb.velocity.y > 0f)
        {
            var v = rb.velocity;
            v.y *= jumpCutMultiplier;
            rb.velocity = v;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player 1 dies in Poison or Water
        if (playerTag == "Player1" && (collision.CompareTag("Poison") || collision.CompareTag("Water")))
        {
           Respawn();
        }

        // Player 2 dies in Poison or Fire
        else if (playerTag == "Player2" && (collision.CompareTag("Poison") || collision.CompareTag("Fire")))
        {
           Respawn();
        }
        
    }

    private void Respawn()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.ResetLevel();
    }
}