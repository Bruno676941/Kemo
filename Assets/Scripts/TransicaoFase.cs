using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoFase : MonoBehaviour
{
    public string fase = SceneManager.GetActiveScene().name;
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
