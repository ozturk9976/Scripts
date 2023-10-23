using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
 public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private Transform barrel;
    [SerializeField] private float fireRate;

    
    [Header("Bullet Settings")]
    [SerializeField] private AudioSource bulletSFX;
    [SerializeField] private GameObject ammo;
    [SerializeField] private float bulletForce;

    //Rotation
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    [Header("Weapon Recoil")]
    //Hipfire Recoil
    [SerializeField] private float recoil_X;
    [SerializeField] private float recoil_Y;
    [SerializeField] private float recoil_Z;

    //Settings Recoil
    [SerializeField] private float recoilSnappiness;
    [SerializeField] private float recoilReturnSpeed;


    private bool isShootButtonHeld;
    private float nextTimeToFire = 0f;
    private PlayerInputActionAsset playerInput;



    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, recoilReturnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, recoilSnappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);

        isShootButtonHeld = INPUT_MANAGER.playerInput.Player.character_shoot.ReadValue<float>() > 0.1f;
        if (isShootButtonHeld && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            RecoilFire(fireRate);
        }
    }

    void RecoilFire(float fireRate)
    {
        GameObject _ammo = Instantiate(ammo, barrel.transform.position, barrel.transform.rotation);
        bulletSFX.Play();
        _ammo.GetComponent<Rigidbody>().velocity = _ammo.transform.forward * bulletForce;

        targetRotation += new Vector3(recoil_X, Random.Range(-recoil_Y, recoil_Y), Random.Range(-recoil_Z, recoil_Z));


    }
}
