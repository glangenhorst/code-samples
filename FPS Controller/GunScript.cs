using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    //Based on basic raycasting tutorials.
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = .06666f;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        //remove nextTimeToFire for non-auto
        //figure this out
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
