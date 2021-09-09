using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 1f;

    void Start()
    {
    }


    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");

        Vector3 NewRotation = transform.localEulerAngles;
        NewRotation.x += _mouseY * _sensitivity;
        transform.localEulerAngles = NewRotation;
    }
}