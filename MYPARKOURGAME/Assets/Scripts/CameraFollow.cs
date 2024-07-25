using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{ 
    public Transform target; // Top nesnesi
    public float distance = 5.0f; // Hedefe olan mesafe
    public float rotationSpeed = 5.0f; // Dönme hızı
    private float currentAngleX = 0f; // Yükseklik açısı
    private float currentAngleY = 0f; // Yatay açı

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // Sağ tık ile döndürme
        {
            currentAngleY += Input.GetAxis("Mouse X") * rotationSpeed;
            currentAngleX -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentAngleX = Mathf.Clamp(currentAngleX, -30f, 60f); // Yükseklik açısını sınırlama
        }

        // Kamerayı konumlandır
        Quaternion rotation = Quaternion.Euler(currentAngleX, currentAngleY, 0);
        Vector3 position = target.position - rotation * Vector3.forward * distance;

        transform.position = position;
        transform.LookAt(target);
    }

}