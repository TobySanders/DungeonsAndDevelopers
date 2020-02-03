using UnityEngine;

public class CharacterBehaviour : PlayerController
{
    public GameObject projectilePrefab;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAct)
        {
            if (Input.GetButtonDown("Fire"))
                FireProjectile(target, 5);
        }
        if (canMove)
        {
            GetMovementInput();
        }
    }

    public override void GetMovementInput()
    {
        //destination += Vector3.forward * gridSize * Input.GetAxisRaw("Vertical");
        if (Input.GetAxis("Horizontal") != 0)
        {
            destination += Vector3.right * gridSize * Input.GetAxisRaw("Horizontal");
            canMove = false;
        }
    }

    public override void FireProjectile(GameObject target, int damage)
    {
        var projectile = GameObject.Instantiate(projectilePrefab, transform.position, transform.rotation);
        var projectileScript = projectile.GetComponent<ProjectileBehaviour>();

        projectileScript.SetValues(target, damage);

        canAct = false;
    }
}
