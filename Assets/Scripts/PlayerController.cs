using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public CharacterController characterController;
    public Transform _cameraTransform;
    private float rotationX;
    private float rotationY;

    [SerializeField] private float moveSpeed = 1f;
    private Vector2 moveInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        Rotate();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Rotate()
    {
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            rotationX += mouseX;
            rotationY -= mouseY;

            _cameraTransform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    private void Move()
    {
        moveInput = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();

        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        transform.Translate(movement, Space.World);
    }
}
