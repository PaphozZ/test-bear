using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterController characterController;
    public Transform _cameraTransform;
    private float rotationX;
    private float rotationY;

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
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
            characterController.Move(new Vector3(0, 0, 1));
        if (Input.GetKey(KeyCode.A))
            characterController.Move(new Vector3(-1, 0, 0));
        if (Input.GetKey(KeyCode.S))
            characterController.Move(new Vector3(0, 0, -1));      
        if (Input.GetKey(KeyCode.D))
            characterController.Move(new Vector3(1, 0, 0));
    }
}
