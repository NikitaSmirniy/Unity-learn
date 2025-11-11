using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanBeDamage
{
    void TakeDamage(DamageType type, int damage);
}
