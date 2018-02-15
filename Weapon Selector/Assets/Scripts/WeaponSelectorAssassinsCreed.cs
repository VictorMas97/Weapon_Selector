using UnityEngine;

public class WeaponSelectorAssassinsCreed : MonoBehaviour
{

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
        if (Input.GetKey(KeyCode.Space))
        {
            weaponSelector.SetActive(true);
        }

        else
        {
            weaponSelector.SetActive(false);
        }
        #endregion

        #region Activate the correct weapon
        if (weaponSelector.activeSelf && Input.GetMouseButtonDown(0))
        {
            RaycastHit target;       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out target))
            {
                if (target.transform.tag == "ShotgunSelect")
                {
                    ActivateWeapon(shotgun);
                }

                else if (target.transform.tag == "SniperSelect")
                {
                    ActivateWeapon(sniper);
                }

                else if (target.transform.tag == "AutomaticWeaponSelect")
                {
                    ActivateWeapon(automaticWeapon);
                }

                else if (target.transform.tag == "SemiAutomaticWeaponSelect")
                {
                    ActivateWeapon(semiAutomaticWeapon);
                }                
            }
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