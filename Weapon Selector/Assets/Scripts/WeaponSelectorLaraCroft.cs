using UnityEngine;

public class WeaponSelectorLaraCroft : MonoBehaviour
{

    [SerializeField] private GameObject weaponSelector;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject sniper;
    [SerializeField] private GameObject automaticWeapon;
    [SerializeField] private GameObject semiAutomaticWeapon;

    private GameObject actuallyWeapon;
    private SpriteRenderer[] spriteR;
    private float alphaChannel;

    void Awake()
    {
        spriteR = weaponSelector.GetComponentsInChildren<SpriteRenderer>();
    }

    void Start()
    {
        actuallyWeapon = automaticWeapon;
    }

    void Update()
    {
        #region Activate the weapon selector and the correct weapon
        if (Input.GetKeyDown("a"))
        {
            ActivateWeapon(shotgun);
        }

        else if (Input.GetKeyDown("w"))
        {
            ActivateWeapon(sniper);
        }

        else if (Input.GetKeyDown("d"))
        {
            ActivateWeapon(automaticWeapon);
        }

        else if (Input.GetKeyDown("s"))
        {
            ActivateWeapon(semiAutomaticWeapon);
        }
        #endregion

        #region Change the alpha and desactivate the weapon selector
        else if (weaponSelector.activeSelf)
        {
            alphaChannel -= 0.5f * Time.deltaTime;
            Color cl = new Color(1, 1, 1, alphaChannel);

            for (int i = 0; i < spriteR.Length; i++)
            {
                spriteR[i].color = cl;
            }

            if (alphaChannel <= 0)
            {
                weaponSelector.SetActive(false);
            }
        }
        #endregion
    }

    void ActivateWeapon(GameObject weapon)
    {
        alphaChannel = 1;
        weaponSelector.SetActive(true);
        actuallyWeapon.SetActive(false);
        weapon.SetActive(true);
        actuallyWeapon = weapon;
    }
}

//if (Input.GetAxis("OpenWeaponSelector") > 0)