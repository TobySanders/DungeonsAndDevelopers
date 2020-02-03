
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update


    public float Speed = 0.5f;
    public int Damage = 1;
    private GameObject _target;

    void Start()
    {
        
    }

    public void SetValues(GameObject target, int damage)
    {
        _target = target;
        Damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.LookAt(_target.transform);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Speed);
        //transform.position += (_target.transform.position - transform.position) * Speed; Vector3.
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyBehaviour>().ApplyDamage(Damage);

            Destroy(gameObject);
        }
    }
}
