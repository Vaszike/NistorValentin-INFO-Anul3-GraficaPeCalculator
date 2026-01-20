using System.Diagnostics;
using UnityEngine;

public class MonedaScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Jucator")
        {
            JocController jucator = other.GetComponent<JocController>();
            if (jucator != null)
            {
                jucator.AdaugaScor();
            }
            Destroy(gameObject);
        }
    }
}