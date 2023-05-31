using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject baseBullet;
    public Transform firePoint;

    private Camera mainCam;
    private Vector3 mousePos;
    float rotZ;

    bool canFire;
    private float timer;
    private int weapon;

    public float timeBetweenFiring;
    public float force;

    // ammo
    public int currentClip, maxClipSize = 10, currentAmo, maxAmmoSize = 100;






    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
        weapon = 0;
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire && currentClip > 0)
        {
            if (weapon == 0){

            canFire = false;
            Instantiate(baseBullet, firePoint.position, Quaternion.identity);
            baseBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * force, ForceMode2D.Impulse);
            }

            else if (weapon == 1){

            canFire = false;
            Instantiate(baseBullet, firePoint.position, Quaternion.identity);
            baseBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * force, ForceMode2D.Impulse);
            }

            else if (weapon == 2){
            canFire = false;

            Instantiate(baseBullet, firePoint.position, Quaternion.identity);
            baseBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * force, ForceMode2D.Impulse);
            }

            currentClip -= 1;
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            weapon += 1;

            if(weapon == 0){
                timeBetweenFiring = 0.3f;
            }

            if(weapon == 1){
                timeBetweenFiring = 0.7f;
            }

            if(weapon == 2){
                timeBetweenFiring = 0.1f;
            }

            if (weapon == 3){
                weapon -= 3;
                timeBetweenFiring = 0.3f;
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){
            Reload();
        }


    }

    public void Reload(){
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmo - reloadAmount) >= 0 ? reloadAmount : currentAmo;
        currentClip += reloadAmount;
        currentAmo -= reloadAmount;
    }

    public void AddAmo(int ammoAmount){
        currentAmo += ammoAmount;
        if(currentAmo > maxAmmoSize){
            currentAmo = maxAmmoSize;
        }
    }


}
