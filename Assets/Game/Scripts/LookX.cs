using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 1f;

    void Start()
    {
    }


    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 NewRotation = transform.localEulerAngles;
        NewRotation.y += _mouseX * _sensitivity;
        transform.localEulerAngles = NewRotation;
    }
}