using UnityEngine;

public class EnemyBLue : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float leftLimitCoordinate = -3f;
    [SerializeField] float rightScreenLimit = 3f;
    bool isGoingLeft = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        Vector2 direction = isGoingLeft ? Vector2.left : Vector2.right;
       transform.Translate(direction * speed * Time.deltaTime);

       if (isGoingLeft && (transform.position.x < leftLimitCoordinate))
        {
            isGoingLeft = false;
        }
         if (isGoingLeft && (transform.position.x > rightScreenLimit))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerShot"))
        {
            Destroy(gameObject);
            
        }
    }
}
