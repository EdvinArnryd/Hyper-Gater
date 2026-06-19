using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private InputSystem_Actions _input;
    private Vector2 _mouseScreenPos;

    void Awake()
    {
        _input = new InputSystem_Actions();

        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMove;
        _input.Player.MousePosition.performed += OnLook;

        if(_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }
    }

    void Update()
    {
        Vector3 mouseWorld = _mainCamera.ScreenToWorldPoint(
            new Vector3(_mouseScreenPos.x, _mouseScreenPos.y, _mainCamera.transform.position.z * -1));

        // float targetX = mouseWorld.x;
        // float newX = Mathf.MoveTowards(transform.position.x, targetX, 5 * Time.deltaTime);

        transform.position = new Vector3(mouseWorld.x, transform.position.y, transform.position.z);
    }

    private void OnEnable()
    {
        _input.Player.Enable();        
    }

    private void OnDisable()
    {
        _input.Player.Disable();       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _mouseScreenPos = context.ReadValue<Vector2>();
    }
}