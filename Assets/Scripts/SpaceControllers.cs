using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float linearVelocity = 3f;
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shot;
    [SerializeField] GameObject prefabShot;
    [SerializeField] Transform shotingPoint;
    Rigidbody2D rb2d;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
}
