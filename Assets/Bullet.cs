using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float time = 5f;
    public float speedMin = 3f;
    public float speedMax = 6f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * Random.Range(speedMin, speedMax);
        Destroy(gameObject, time*3);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent <PlayerController>();
            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }

}
