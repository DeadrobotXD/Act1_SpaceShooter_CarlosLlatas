using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float linearVelocity = 3f;
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shot;
    [SerializeField] GameObject prefabShot;
    [SerializeField] Transform shotingPoint;
    [SerializeField] AudioClip clip;

    Rigidbody2D rb2d;
    Vector2 startPosition;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        move.action.started += OnMove;
        move.action.canceled += OnMove;
        move.action.performed += OnMove;
        shot.action.started += OnShot;
        
    } 

    private void OnEnable()
    {
        move.action.Enable();
        shot.action.Enable();
    }
    private void Update()
    {
        rb2d.linearVelocity = rawMove * linearVelocity;
    }
    private void OnDisable()
    {
        move.action.Disable();
        shot.action.Disable();
    }
    Vector2 rawMove = Vector2.zero;

    void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.action.ReadValue<Vector2>();
    }
    private void OnShot(InputAction.CallbackContext obj)
    {
        Instantiate(prefabShot, shotingPoint.position, Quaternion.identity);
        

    }


    // Destruccion de nave al chocar con enemigo, se resetea su posicion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            ResetShip();

        }

    }
    internal void ResetShip()
    {
        transform.position = startPosition;
    }
}
