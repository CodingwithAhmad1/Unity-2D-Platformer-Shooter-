using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GunName : MonoBehaviour
{
    public TextMeshProUGUI gunText;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGunText();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGunText();
    }

    public void UpdateGunText(){
        gunText.text = $"Gun: {weapon.guns}";
    }
}
