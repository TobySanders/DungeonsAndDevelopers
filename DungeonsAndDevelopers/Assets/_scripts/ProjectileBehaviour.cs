
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public float speed = 0.5f;

    void Start()
    {
        
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
        transform.LookAt(target.transform);
        transform.position += (target.transform.position - transform.position) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyBehaviour>().ApplyDamage();

            Destroy(gameObject, 1);
        }
    }
}
