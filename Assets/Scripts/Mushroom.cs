using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] Sprite[] states;
    
    public int points = 1;

    SpriteRenderer spriteRenderer;
    int health;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = states.Length;
    }

    void Damage(int amount)
    {
        health -= amount;

        if(health > 0)
        {
            spriteRenderer.sprite = states[states.Length - health];
        }
        else
        {
            Destroy(gameObject);
            GameManager.Instance.IncreaseScore(points);
        }
    }

    public void Heal()
    {
        health = states.Length;
        spriteRenderer.sprite = states[0];
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Dart"))
        {
            Damage(1);

        }    
    }

}
