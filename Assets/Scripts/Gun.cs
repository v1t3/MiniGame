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
    private float _timer;

    [SerializeField] private AudioSource shotSound;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > shotPeriod && Input.GetMouseButtonDown(0))
        {
            _timer = 0;
            Shot();
        }
    }

    private void Shot()
    {
        var newBullet = Instantiate(bulletPrefab, spawn.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = spawn.forward * bulletSpeed * Time.deltaTime;
        
        shotSound.Play();
        StartCoroutine(ShowFlash());
    }

    private IEnumerator ShowFlash()
    {
        flash.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        
        flash.SetActive(false);
    }
}