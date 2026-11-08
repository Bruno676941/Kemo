using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoFase : MonoBehaviour
{
    public string fase = "Fase2";

  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(fase);
        }
    }
}
