using System.Diagnostics;
using UnityEngine;

public class PowerUpSaritura : MonoBehaviour
{
    public float bonusSaritura = 4f;

    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Jucator")
        {
            JocController jucatorScript = other.GetComponent<JocController>();

            if (jucatorScript != null)
            {
                jucatorScript.fortaSaritura += bonusSaritura;
                jucatorScript.ActiveazaTextPowerUp();
                UnityEngine.Debug.Log("Super Saritura Activata! Forta noua: " + jucatorScript.fortaSaritura);
            }
            Destroy(gameObject);
        }
    }
}