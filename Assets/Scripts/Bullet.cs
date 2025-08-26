using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject explotionPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {

        if (Collision.gameObject.tag == "Enemy")
        {
            Instantiate(explotionPrefab, transform.position, Quaternion.identity);
            Destroy(Collision.gameObject);
            Destroy(gameObject);
          
        }
        if (Collision.gameObject.tag == "Boundary")
        {
           
            Destroy(gameObject);
        }
    }

  
}
