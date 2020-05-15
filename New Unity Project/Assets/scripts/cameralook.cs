using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Camera-Control/cameralook")]
public class cameralook : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    };

    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityX = 2.0F;
    public float sensitivityY = 2.0F;

    public float minimumX = -360F;
    public float maximumX = 360F;
    
    public float minimumY = -360F;
    public float maximumY = 360F;

    private float rotationX = 0F;
    private float rotationY = 0F;

    private Quaternion originalRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
            
        }
        originalRotation = transform.localRotation;
    }

    public static float ClamplAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseXandY)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationX = ClamplAngle(rotationX, minimumX, maximumX);
            rotationY = ClamplAngle(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            transform.localRotation = originalRotation* xQuaternion* yQuaternion;
        } 
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClamplAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation* xQuaternion;
        }
        
        else if (axes == RotationAxes.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClamplAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation* yQuaternion;
        }
    }
}
