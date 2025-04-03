using System;
using Cinemachine;
using UnityEngine;
using StarterAssets;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO startingWeaponSo;
    [SerializeField] private Image zoomVignette;
    [SerializeField] private CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] private TMP_Text ammoText;
    
    private WeaponSO _currentWeaponSo;
    private Animator _animator;
    private StarterAssets.StarterAssets _starterAssets;
    FirstPersonController _firstPersonController;
    private Weapon _currentWeapon;
    
    private float _timeSinceLastShot;
    private float _defaultFOV;
    private float _defaultRotationSpeed;
    private int currentAmmo;

    private const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        _starterAssets = GetComponentInParent<StarterAssets.StarterAssets>();
        _firstPersonController = GetComponentInParent<FirstPersonController>();
        _animator = GetComponent<Animator>();
        _defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        _defaultRotationSpeed = _firstPersonController.RotationSpeed;
    }

    private void Start()
    {
        SwitchWeapon(startingWeaponSo);
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;

        if (currentAmmo > _currentWeaponSo.MagazineSize)
        {
            currentAmmo = _currentWeaponSo.MagazineSize;
        }
        
        ammoText.text = currentAmmo.ToString("D2");
        
    }

    private void HandleShoot()
    {
        if (!_starterAssets.shoot) return;

        if (_timeSinceLastShot >= _currentWeaponSo.FireRate && currentAmmo > 0)
        {
            _currentWeapon.Shoot(_currentWeaponSo);
            _animator.Play(SHOOT_STRING, 0, 0f);
            _timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if (!_currentWeaponSo.IsAutomatic)
        {
            _starterAssets.ShootInput(false);
        }
        
    }

    private void HandleZoom()
    {
        if (!_currentWeaponSo.CanZoom) return;
        
        // ReSharper disable once LocalVariableHidesMember
        var renderer = GetComponentInChildren<MeshRenderer>();

        if (_starterAssets.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = _defaultFOV - _currentWeaponSo.ZoomAmount;
            zoomVignette.enabled = true;
            renderer.enabled = false;
            _firstPersonController.ChangeRotationSpeed(_currentWeaponSo.ZoomRotationSpeed);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = _defaultFOV;
            zoomVignette.enabled = false;
            renderer.enabled = true;
            _firstPersonController.ChangeRotationSpeed(_defaultRotationSpeed);
        }
    }
    
    public void SwitchWeapon(WeaponSO weaponType)
    {
        if (_currentWeapon)
        {
            Destroy(_currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponType.WeaponPrefab, transform).GetComponent<Weapon>();
        _currentWeapon = newWeapon;
        _currentWeaponSo = weaponType;
        AdjustAmmo(-currentAmmo + _currentWeaponSo.MagazineSize);
    }
}
