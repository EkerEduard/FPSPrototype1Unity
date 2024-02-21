using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float vertivalRot = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }
    }

    private void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            //������� � �������������� ���������
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        } 
        else if(axes == RotationAxes.MouseY)
        {
            //������ � ������������ ���������
            vertivalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            vertivalRot = Mathf.Clamp(vertivalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(vertivalRot, horizontalRot, 0);
        }
        else
        {
            //��������������� ������
            vertivalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            vertivalRot = Mathf.Clamp(vertivalRot, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(vertivalRot, horizontalRot, 0) ;
        }
    }
}
