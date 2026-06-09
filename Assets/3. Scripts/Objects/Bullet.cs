 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * movespeed * Time.deltaTime);

        if(!StageManager.stage.isstart)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<HitBox>(out HitBox hit);
        bool ishit = hit.enabled;

        if (ishit)
        {
            hit.Damaged(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
