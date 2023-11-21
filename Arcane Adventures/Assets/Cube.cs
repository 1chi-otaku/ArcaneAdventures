using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Cube : MonoBehaviour
{
    BoxCollider col;
    public Manager manager;
    public int number;
    public int numberCell;
    void Start()
    {
        col= GetComponent<BoxCollider>();
    }
    private void OnMouseDown()
    {
        if (!manager.isWin)
        {
            col.enabled = false;
            RaycastHit hit;
            if (!Physics.Linecast(transform.position, transform.position - transform.right * 2.45f, out hit))
            {
                transform.position = new Vector3(transform.position.x + 2.45f, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + transform.right * 2.45f, out hit))
            {
                transform.position = new Vector3(transform.position.x - 2.45f, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position - transform.forward * 2.45f, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2.45f);
            }
            else if (!Physics.Linecast(transform.position, transform.position + transform.forward * 2.45f, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2.45f);
            }
            col.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger")
        {
            numberCell = other.transform.GetComponent<NumberCell>().numberCell;
            manager.win();
        }
    }
}
