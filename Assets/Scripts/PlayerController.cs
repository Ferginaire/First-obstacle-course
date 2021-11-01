using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool cursorVisibility = true;

    [SerializeField]
    float jumpHeight;

    float distToGround = 1;
    bool stopped = false;
    
    [SerializeField]
    Transform playerCamera = null;

    [SerializeField]
    float mouseSensitivity = 3.5f;

    [SerializeField]
    float walkSpeed = 30f;

    
    ////[SerializeField]
    ////float distToGround = 0.0f;

    [SerializeField]
    bool lockCursor = true;

    float cameraPitch = 0.0f;
    float horizontalMovement;
    float verticalMovement;
    Vector3 moveDirection;

    Rigidbody rb;

    public GameObject winMessage;
    public GameObject deathMessage;
    public GameObject player;
    public GameObject timer;
    float time = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncrementTimer());
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = cursorVisibility;
        }

        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded()) {
            GetComponent<Rigidbody>().drag = 6;
            walkSpeed = 50;
        } else
        {
            GetComponent<Rigidbody>().drag = 1;
            walkSpeed = 10;
        }
        UpdateMouseLook();
        if (stopped == false)
        {
            UpdateMovement();
        }
        
    }

    void UpdateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);

        cameraPitch -= mouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
    }



    void UpdateMovement()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }

        

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        moveDirection.Normalize();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * jumpHeight * 4, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            winMessage.SetActive(true); 
            stopped = true;
        }
        if (other.transform.CompareTag("Death"))
        {
            deathMessage.SetActive(true);
            StartCoroutine(StartRespawn());

        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection * walkSpeed, ForceMode.Acceleration); 
        //Debug.Log(moveDirection * walkSpeed);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    IEnumerator StartRespawn()
    {
        yield return new WaitForSeconds(3);
        player.transform.position = new Vector3(0, 0, 0);
        deathMessage.SetActive(false);
        time = 0;
    }

    IEnumerator IncrementTimer()
    {
        if (stopped != true)
        {
            yield return new WaitForSeconds(1);
            if (stopped != true)
            {
                time++;
                timer.GetComponent<UnityEngine.UI.Text>().text = time.ToString() + "s";
                StartCoroutine(IncrementTimer());
            }
        }
    }
}
