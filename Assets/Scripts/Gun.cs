using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletSpawn;
    private float bulletSpeed = 1500f;
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_input.shoot) 
        {
            Shoot();
            _input.shoot = false;
        }
    }

    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * -bulletSpeed);
        Destroy(bullet, 1);
        Debug.Log("ammo fired");
    }
}
