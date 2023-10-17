using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] Rigidbody2D myRigid;

    Vector2 input;
    Vector2 spawnPosition;

    void Awake() 
    {
        spawnPosition = transform.position;    
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate() 
    {
        Move();
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
        gameObject.SetActive(true);
    }

    void Move()
    {
        Vector2 position = myRigid.position;
        position += input.normalized * moveSpeed * Time.fixedDeltaTime;

        myRigid.MovePosition(position);
    }

}
