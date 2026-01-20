using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JocController : MonoBehaviour
{
    public float vitezaMiscare = 5f;
    public float sensibilitateMouse = 100f;
    public float fortaSaritura = 5f;
    public Transform cameraJucator;
    public TextMeshProUGUI textScor;
    public GameObject panelCastig;
    public GameObject textPowerUp;
    private Rigidbody rb;
    private int scor = 0;
    float rotatieX = 0f;
    private bool jocTerminat = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        ActualizeazaText();
        if (panelCastig != null) panelCastig.SetActive(false);
        if (textPowerUp != null) textPowerUp.SetActive(false);
    }

    void Update()
    {
        if (jocTerminat) return;

        // CAMERA
        float mouseX = Input.GetAxis("Mouse X") * sensibilitateMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilitateMouse * Time.deltaTime;

        rotatieX -= mouseY;
        rotatieX = Mathf.Clamp(rotatieX, -90f, 90f);

        cameraJucator.localRotation = Quaternion.Euler(rotatieX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // MISCARE
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 directieMiscare = transform.right * x + transform.forward * z;
        Vector3 vitezaNoua = directieMiscare * vitezaMiscare;

        rb.linearVelocity = new Vector3(vitezaNoua.x, rb.linearVelocity.y, vitezaNoua.z);

        // SARITURA
        if (Input.GetKeyDown(KeyCode.Space) && EstePePamant())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * fortaSaritura, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None;
    }

    bool EstePePamant()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    }

    public void AdaugaScor()
    {
        scor++;
        ActualizeazaText();
        if (scor >= 5)
        {
            Victorie();
        }
    }

    void Victorie()
    {
        jocTerminat = true;
        if (panelCastig != null)
        {
            panelCastig.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void IncarcaMeniul()
    {
        SceneManager.LoadScene(0);
    }

    public void ActiveazaTextPowerUp()
    {
        if (textPowerUp != null)
        {
            textPowerUp.SetActive(true);
            Invoke("AscundeTextPowerUp", 3f);
        }
    }

    void AscundeTextPowerUp()
    {
        if (textPowerUp != null)
        {
            textPowerUp.SetActive(false);
        }
    }
    void ActualizeazaText()
    {
        if (textScor != null) textScor.text = "Obiectiv: Strânge monedele! (" + scor + "/5)";
    }
}