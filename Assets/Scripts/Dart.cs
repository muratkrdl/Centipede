using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigid;
    [SerializeField] new Collider2D collider;
    [SerializeField] float moveSpeed = 10f;

    Transform parent;

    void Awake() 
    {
        myRigid.bodyType = RigidbodyType2D.Kinematic;
        collider.enabled = false;
        parent = transform.parent;    
    }

    void Update() 
    {
        if(myRigid.isKinematic && Input.GetButton("Fire1"))
        {
            transform.SetParent(null);
            myRigid.bodyType = RigidbodyType2D.Dynamic;
            collider.enabled = true;
        }    
    }

    void FixedUpdate() 
    {
        if(!myRigid.isKinematic)
        {
            Vector2 newPos = myRigid.position;
            newPos += Vector2.up * moveSpeed * Time.fixedDeltaTime;
            myRigid.MovePosition(newPos);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        transform.SetParent(parent);
        transform.localPosition = new Vector3(0, .5f, 0);
        myRigid.bodyType = RigidbodyType2D.Kinematic;
        collider.enabled = false;
    }

}
