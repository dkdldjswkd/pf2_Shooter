using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;
    Gun equippedGun;

    public void EquipGun(Gun ghunToEquip)
    {
        if (equippedGun != null)
            Destroy(equippedGun.gameObject);
        equippedGun = Instantiate(ghunToEquip, weaponHold.position, weaponHold.rotation);
    }


}
