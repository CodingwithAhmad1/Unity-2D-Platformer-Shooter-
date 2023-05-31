using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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

    // ammo, gun
    public int currentClip, maxClipSize = 10, currentAmmo, maxAmmoSize = 100;
    public string guns;






    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
        weapon = 0;
        currentClip = 10;
        currentAmmo = 100;
        
        guns = "Assault Rifle";
        timeBetweenFiring = 0.3f;
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

            else if (weapon == 1 && currentClip >= 4){
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
            if (weapon == 2){
                weapon = 0;
            }
            else{
            weapon += 1;
            }

            if(weapon == 0){
                timeBetweenFiring = 0.3f;
                guns = "Assault Rifle";
                Reload();
                
                maxClipSize = 10;
                currentClip = maxClipSize;
            }

            if(weapon == 1){
                timeBetweenFiring = 0.7f;
                guns = "Sniper" ;
                Reload();

                maxClipSize = 6;            
                currentClip = maxClipSize;
            }

            if(weapon == 2){
                timeBetweenFiring = 0.1f;
                guns = "Machine Gun";
                Reload();

                maxClipSize = 20;
                currentClip = maxClipSize;
            }

        }

        if(Input.GetKeyDown(KeyCode.R)){
            Reload();
        }


    }

    public void Reload(){
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmo(int ammoAmount){
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize){
            currentAmmo = maxAmmoSize;
        }
    }
}
