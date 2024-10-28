using UnityEngine;
using TMPro;

public class PointCollector : MonoBehaviour
{
    public int puntos = 0; 
    [SerializeField] private TextMeshProUGUI contadorDePuntos; 

    void Start()
    {
        ActualizarContadorDePuntos();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Cubiertos"))
        {
            SumarPuntos(1);
        }
        else if (collision.gameObject.CompareTag("Florero") &&
                 (Mathf.Approximately(collision.gameObject.transform.eulerAngles.x, 90) ||
                  Mathf.Approximately(collision.gameObject.transform.eulerAngles.y, 90) ||
                  Mathf.Approximately(collision.gameObject.transform.eulerAngles.z, 90)))
        {
            SumarPuntos(5);
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log("Total puntos: " + puntos); 
        ActualizarContadorDePuntos(); 
    }

    private void ActualizarContadorDePuntos()
    {
        if (contadorDePuntos != null)
        {
            contadorDePuntos.text = "Puntos: " + puntos.ToString();
        }
        else
        {
            Debug.LogWarning("El objeto contadorDePuntos no está asignado.");
        }
    }
}
