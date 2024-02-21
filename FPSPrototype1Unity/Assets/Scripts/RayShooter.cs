using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 1;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    private void Update()
    {
        // ������������� ����
        if(Input.GetMouseButton(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0); // ���������� ����� ������
            Ray ray = cam.ScreenPointToRay(point); // ������� ���
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                StartCoroutine(SphereIndicator(hit.point));
                //Debug.Log("Hit " + hit.point);
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
