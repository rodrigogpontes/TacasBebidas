using UnityEngine;

public class ControladorGarrafa : MonoBehaviour
{
    public ControladorFase geral;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            geral.Comparar();
    }
}
