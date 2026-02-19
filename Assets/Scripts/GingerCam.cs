using UnityEngine;

public class GingerCam : MonoBehaviour
{
    public Transform ginger;

    public float xSensitivity;
    public float ySensitivity;

    public float xRotation;
    public float yRotation;

    // Start is called before the first frame update
    public void Start()
    {
        // lock the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // make the cursor invisible
        Cursor.visible = false;
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        ginger.rotation = Quaternion.Euler(0, yRotation, 0);

        transform.position = new Vector3(ginger.position.x, ginger.position.y + 0.2f, ginger.position.z);
    }
}
