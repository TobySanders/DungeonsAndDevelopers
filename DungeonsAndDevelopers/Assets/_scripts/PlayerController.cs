using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gridSize = 1f;
    public float speed = 0.5f;
    public float movementDeadzone = 0.0001f;
    public int Initiative;
    public int Id;

    protected Vector3 destination;
    protected Vector3 movement;

    protected bool canMove = false;
    protected bool canAct = false;
    


    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            GetMovementInput();
        }
    }

    private void FixedUpdate()
    {
        UpdatePosition();
    }

    public virtual void RollInitiative()
    {
        Initiative = Random.Range(0,20);
    }

    public virtual void FireProjectile(GameObject target, int damage)
    {
    }

    public virtual void StartTurn()
    {
        Debug.Log($"starting turn for player id:{Id}");
        canMove = true;
        canAct = true;
    }

    public virtual void GetMovementInput()
    {
    }


    public virtual void OnTriggerEnter(Collider other)
    {
    }

    private void UpdatePosition()
    {
        //if(Vector3.Distance(destination, transform.position) <= movementDeadzone)
        //{
        //    destination = transform.position;
        //    return;
        //}

        movement = (destination - transform.position) * speed;
        transform.position += movement;
    }


}
