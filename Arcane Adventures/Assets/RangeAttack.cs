using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject armPrefab;
    public void Shoot()
    {
        Instantiate(armPrefab,firePoint.position,firePoint.rotation);
    }
}
