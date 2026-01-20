using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuController : MonoBehaviour
{
    public void PornesteJoc()
    {
        SceneManager.LoadScene(1);
    }
    public void IesiDinJoc()
    {
        UnityEngine.Debug.Log("IESIRE!");
        Application.Quit();
    }
}