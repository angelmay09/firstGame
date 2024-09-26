using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[RequireComponent(typeof(CharacterController))]
public class PlayerComponent : MonoBehaviour
{
    public string playerName;
    public float moveSpeed = 10f;
    public float rotationSpeed = 1f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float shootDelay = 0.01f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform Spawner;
    public float bulletForce = 3;

    private AudioSource shootSound;
    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        shootSound = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        #region Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rotation = new Vector3(0,Input.GetAxis("Mouse X"),0);       
        characterController.Move(movement * Time.deltaTime *moveSpeed);
        transform.Rotate(rotation);
    
        #endregion

        #region Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            shootSound.Play();
            Shoot();
        }
        #endregion
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, Spawner.position, Spawner.transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bullet.transform.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 5.0f);
    }
}
