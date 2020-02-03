using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gridSize = 1f;
    public float speed = 0.5f;
    public float movementDeadzone = 0.0001f;

    Vector3 destination;
    Vector3 movement;

    bool isMoving = false;
    


    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            GetMovementInput();
        }
    }

    private void FixedUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if(Vector3.Distance(destination, transform.position) <= movementDeadzone)
        {
            destination = transform.position;
            isMoving = false;
            return;
        }
        movement = (destination - transform.position) * speed;
        transform.position += movement;
    }

    private void GetMovementInput()
    {
        //destination += Vector3.forward * gridSize * Input.GetAxisRaw("Vertical");
        destination += Vector3.right * gridSize * Input.GetAxisRaw("Horizontal");
        isMoving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            
        }
    }
}
