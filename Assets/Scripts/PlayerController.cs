using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focalPoint;
    public GameObject powerIndicator;
    public bool hasPowerUp = false;
    public float speed;
    private float powerStrange = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * forwardInput * speed);
       powerIndicator.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            StartCoroutine(PowerCountdown());
            powerIndicator.SetActive(true);
        }
    }

    IEnumerator PowerCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerIndicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
           Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerStrange, ForceMode.Impulse);
        }
    }
}
