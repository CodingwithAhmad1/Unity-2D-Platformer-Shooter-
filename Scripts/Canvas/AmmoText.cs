using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class AmmoText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmoText();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText(){
        text.text = $"{weapon.currentClip} / {weapon.maxClipSize} | {weapon.currentAmmo} / {weapon.maxAmmoSize}";
    }
}
