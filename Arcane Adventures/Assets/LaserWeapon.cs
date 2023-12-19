using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    public Transform laserPoint;
    public GameObject laserPrefab;
    public void Laser()
    {
        Instantiate(laserPrefab, laserPoint.position, laserPoint.rotation);
    }
}
