using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomField : MonoBehaviour
{
    [SerializeField] Mushroom prefab;
    [SerializeField] int amount = 50;

    BoxCollider2D area;

    void Awake() 
    {
        area = GetComponent<BoxCollider2D>();   
    }

    void Start() 
    {
        Generate();
    }

    public void Generate()
    {
        Bounds bounds = area.bounds;

        for (int i = 0; i < amount; i++)
        {
            Vector2 position = Vector2.zero;

            position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            Mushroom mushroom = Instantiate(prefab, position, Quaternion.identity, transform);
        }
    }
    
    public void Clear()
    {
        Mushroom[] mushrooms = FindObjectsOfType<Mushroom>();

        foreach (var item in mushrooms)
        {
            Destroy(item.gameObject);
        }
    }

    public void Heal()
    {
        Mushroom[] mushrooms = FindObjectsOfType<Mushroom>();

        foreach (var item in mushrooms)
        {
            item.Heal();
        }
    }

}
