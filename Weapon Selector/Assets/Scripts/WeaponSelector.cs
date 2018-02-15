using UnityEngine;

public class WeaponSelector : MonoBehaviour {

    [SerializeField] private GameObject weaponSelector;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject sniper;
    [SerializeField] private GameObject automaticWeapon;
    [SerializeField] private GameObject semiAutomaticWeapon;

    private GameObject actuallyWeapon;

    void Start()
    {
        actuallyWeapon = automaticWeapon;
    }

    void Update()
    {
        #region Activate and desactivate the weapon selector
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!weaponSelector.activeSelf)
            {
                weaponSelector.SetActive(true);
            }

            else
            {
                weaponSelector.SetActive(false);
            }
        }
        #endregion

        #region Activate the correct weapon
        else if (weaponSelector.activeSelf && Input.GetKeyDown("a"))
        {
            ActivateWeapon(shotgun);
        }

        else if (weaponSelector.activeSelf && Input.GetKeyDown("w"))
        {
            ActivateWeapon(sniper);
        }

        else if(weaponSelector.activeSelf && Input.GetKeyDown("d"))
        {
            ActivateWeapon(automaticWeapon);
        }

        else if(weaponSelector.activeSelf && Input.GetKeyDown("s"))
        {
            ActivateWeapon(semiAutomaticWeapon);
        }
        #endregion
    }

    void ActivateWeapon(GameObject weapon)
    {
        actuallyWeapon.SetActive(false);
        weapon.SetActive(true);
        actuallyWeapon = weapon;
    }
}
