using UnityEngine;

public class DashAfterImage : MonoBehaviour
{
    public float lifeTime = 0.3f;
    public float fadeSpeed = 5f;

    private SpriteRenderer sr;
    private Color color;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        color = sr.color;
    }

    void Update()
    {
        color.a -= fadeSpeed * Time.deltaTime;
        sr.color = color;

        if (color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
