using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    private CharacterController _controller;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private GameObject _hitMarkerPrefab;
    [SerializeField] private AudioSource _weaponAudio;
    [SerializeField] private GameObject _weapon;

    private int _maxAmmo = 50;
    [SerializeField] private int _currentAmmo;

    private bool _isReloading;

    private UIManager _uiManager;

    public bool hasCoin = false;
    public bool weaponEnabled = false;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = _maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }


    void Update()
    {
        if (hasCoin == true)
        {
            _uiManager.HasCoin();
        }
        else
        {
            _uiManager.HasNoCoin();
        }

        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _uiManager.EnableReload();
            _isReloading = true;
            StartCoroutine(ReloadRoutine());
        }

        if (Input.GetMouseButton(0) && _currentAmmo > 0 && _isReloading == false)
        {
            if (_currentAmmo > 0)
            {
                Shoot();
            }

            if (_weaponAudio.isPlaying == false)
            {
                _weaponAudio.Play();
            }
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }

        Movement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Movement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * _playerSpeed;
        velocity.y -= _gravity;

        //converting local space to world space
        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);
    }

    void Shoot()
    {
        if (weaponEnabled == true)
        {
            _muzzleFlash.SetActive(true);
            _currentAmmo--;
            _uiManager.UpdateAmmo(_currentAmmo);
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
                GameObject hitmarker =
                    Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(hitmarker, 2f);
            }
        }
    }

    IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(3f);
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmo(_currentAmmo);
        _isReloading = false;
        _uiManager.DisableReload();
    }

    public void EnableWeapon()
    {
        _weapon.SetActive(true);
        weaponEnabled = true;
    }
}