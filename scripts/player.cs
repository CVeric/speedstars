using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed = 10f ;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float gravity = -13.0f;


    [SerializeField] Transform playercamera = null;
    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    [SerializeField] bool lockCursor = true;
    CharacterController controller = null;
    BoxCollider hitbox = null;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmooth = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmooth = 0.03f;


    [SerializeField] AnimationCurve JumpFalloff;
    [SerializeField] float jumpMultiplier;
    [SerializeField] KeyCode jumpKey;

    bool isJumping;

    [SerializeField] float maxHealth = 100.0f;
    [SerializeField] float currHealth;
    [SerializeField] float healthRegen = .5f;
    [SerializeField] int expNeeded = 100;
    [SerializeField] int currentEXP = 0;




    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;




    void Start()
    {
        controller = GetComponent<CharacterController>();
        hitbox = GetComponent<BoxCollider>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        updateMovement();
        damaged();
    }
    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmooth);

        cameraPitch -= currentMouseDelta.y* mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playercamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);

    }
    void updateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmooth);
        jumpInput();
        if (!controller.isGrounded)
        {
            GetComponent<Rigidbody>();
        }

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }
    void jumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(jumpEvent());
        }
    }
    IEnumerator jumpEvent()
    {
        controller.slopeLimit = 90.0f;
        float airTime = 0.0f;
        do
        {
            float jumpForce = JumpFalloff.Evaluate(airTime);
            controller.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            airTime += Time.deltaTime;
            yield return null;
        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        controller.slopeLimit = 45.0f; 

        isJumping = false;

    }
    void damaged()
    {

    }

    void checkHealth()
    {
        while(currHealth != maxHealth)
        {
            currHealth += healthRegen;
        }

    }
}
