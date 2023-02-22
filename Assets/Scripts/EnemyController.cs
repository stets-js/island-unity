using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(moveDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
