using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyBullet : MonoBehaviour
{
    private TilemapCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<TilemapCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
        }
    }
}
