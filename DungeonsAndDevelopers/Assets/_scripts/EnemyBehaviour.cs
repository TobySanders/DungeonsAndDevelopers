using UnityEngine;

public class EnemyBehaviour : PlayerController
{
    public float Health = 10;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    public void ApplyDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
            Destroy(gameObject);
    }

    public override void GetMovementInput()
    {
        destination += Vector3.back * gridSize;
        canMove = false;
    }
}
