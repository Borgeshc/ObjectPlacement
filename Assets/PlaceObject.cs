using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(objectToPlace, transform.position, transform.rotation);
        }
    }
}
