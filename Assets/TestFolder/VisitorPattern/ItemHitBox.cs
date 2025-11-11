using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHitBox : HitBox
{
    public override void DefaultOverlapVisit(ColdWeapon coldWeapon)
    {
        print("cold gun");
    }

    public override void DefaultRaycastVisit(RaycastWeapon fireWeapon, RaycastHit hit)
    {
        print("fire gun");
    }
}