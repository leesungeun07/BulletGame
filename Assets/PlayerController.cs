using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("앞으로~");
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + speed * Time.deltaTime
                );
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("뒤로~");
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z - speed * Time.deltaTime
                );
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽으로");
            transform.position = new Vector3(
                transform.position.x - speed * Time.deltaTime,
                transform.position.y,
                transform.position.z
                );
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽으로");
            transform.position = new Vector3(
                transform.position.x + speed * Time.deltaTime,
                transform.position.y,
                transform.position.z
                );
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
