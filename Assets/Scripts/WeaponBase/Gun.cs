using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject flash;
    
    [SerializeField] private Transform spawn;
    
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float shotPeriod = 0.2f;

    [SerializeField] private AudioSource shotSound;
    
    [SerializeField] private bool automatic;
    
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        var inputType = automatic ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0);
        
        if (_timer > shotPeriod && inputType)
        {
            _timer = 0;
            Shot();
        }
    }

    public virtual void Shot()
    {
        var newBullet = Instantiate(bulletPrefab, spawn.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = spawn.forward * bulletSpeed;
        
        shotSound.Play();
        StartCoroutine(ShowFlash());
    }

    private IEnumerator ShowFlash()
    {
        flash.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        
        flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int bulletsCount)
    {
    }
}