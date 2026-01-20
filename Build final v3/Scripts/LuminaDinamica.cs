using UnityEngine;

public class LuminaDinamica : MonoBehaviour
{
    private Light lumina;

    public float intensitateMinima = 10f;
    public float intensitateMaxima = 50f;
    public float vitezaPuls = 2f;

    void Start()
    {
        lumina = GetComponent<Light>();
    }

    void Update()
    {
        float valoare = Mathf.PingPong(Time.time * vitezaPuls, 1);
        lumina.intensity = Mathf.Lerp(intensitateMinima, intensitateMaxima, valoare);
    }
}