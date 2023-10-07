using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 3;
    public float cameraDistance = 0.1f;
    public float minYAngle = -89;
    public float maxYAngle = 89;

    private float currentX;
    private float currentY;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;

        LockCursor(true);
    }

    private void Update()
    {
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LockCursor(false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LockCursor(true);
        }
    }

    private void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -cameraDistance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 targetPosition = target.position + rotation * direction;
        transform.position = targetPosition;
        transform.LookAt(target.position);

        target.rotation = Quaternion.Euler(0, currentX, 0);
    }

    private void HandleRotation()
    {
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    private void LockCursor(bool isTrue)
    {
        if (isTrue)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (!isTrue)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
