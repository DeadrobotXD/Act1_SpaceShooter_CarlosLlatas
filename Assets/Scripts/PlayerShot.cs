using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 3f;
    Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D=GetComponent<Rigidbody2D>();
    }
    
    
    
    void Start()
    {
       rb2D.linearVelocity = Vector2.right * speed;
       Destroy(gameObject, 5f); 
    }

    // Update is called once per frame
     void OnCollisionEnter2D(Collision2D collision)
    {
         Destroy(gameObject);
    }
}
