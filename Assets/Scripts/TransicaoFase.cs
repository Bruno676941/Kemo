using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoFase : MonoBehaviour
{
    public string fase = "Fase2";
    public Inventario inventario;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventario != null && inventario.Chaves >= 1)
            {
                SceneManager.LoadScene(fase);
            }
        }
    }
}
