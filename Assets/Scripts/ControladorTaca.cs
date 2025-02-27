using Unity.VisualScripting;
using UnityEngine;

public class ControladorTaca : MonoBehaviour
{
    public string tipo;
    public ControladorFase geral;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            // O "gameObject" abaixo é o objeto que está com o script ControladorTaca
            // ou seja, o copinho que foi tocado.
            geral.PegarTaca(gameObject);

            Debug.Log(tipo);
        }
    }
}
