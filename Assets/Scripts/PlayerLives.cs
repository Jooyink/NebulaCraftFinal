using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLives : MonoBehaviour
{
    public Image[] livesUI;
    // Start is called before the first frame update
    public GameObject explotionPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.collider.gameObject.tag == ("Enemy"))
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explotionPrefab, transform.position, Quaternion.identity);
            GameManager.instance.vida -= 1;

            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < GameManager.instance.vida)
                {
                    livesUI[i].enabled = true;
                    
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }


            if (GameManager.instance.vida <= 0)
            {
                Destroy(gameObject);
            }


        }

    }


}
