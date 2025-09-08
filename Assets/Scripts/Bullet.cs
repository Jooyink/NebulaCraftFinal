using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject explotionPrefab;
    private PointManager pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }


    private void OnTriggerEnter2D(Collider2D Collision)
    {

        if (Collision.gameObject.tag == "Enemy")
        {
            Instantiate(explotionPrefab, transform.position, Quaternion.identity);
            Destroy(Collision.gameObject);
            pointManager.UpdateScore(50);
            Destroy(gameObject);

        }
        if (Collision.gameObject.tag == "Boundary")
        {

            Destroy(gameObject);
        }
       // if (Collision.gameObject.tag == "EnemyProyectile")  // ESTE CÓDIGO FUNCIONA PARA ELIMINAR LOS PROYECTILES DE ENEMIGOS
        //{ 
         //   Destroy(Collision.gameObject);
        //    Destroy(gameObject);

        
         // }
    }
      
  
}
