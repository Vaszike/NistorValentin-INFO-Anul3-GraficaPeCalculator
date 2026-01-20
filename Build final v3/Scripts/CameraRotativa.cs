using UnityEngine;

public class CameraRotativa : MonoBehaviour
{
    public float vitezaRotatie = 5f;

    void Update()
    {
        transform.Rotate(0, vitezaRotatie * Time.deltaTime, 0);
    }
}