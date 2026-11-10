using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class TransicaoFase : MonoBehaviour
{
    public Inventario inventario;

    public GameObject TelaTransicao;
    public TMP_Text textoFase;

    public string proximaFase;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (inventario == null || inventario.Chaves < 1)
            return;

        inventario.Chaves--;
        inventario.AtualizarInventario();

        if (SceneManager.GetActiveScene().name == "Fase1")
        {
            proximaFase = "Fase2";
            StartCoroutine(MostrarFase(2, "Esgotos"));
        }
        else if (SceneManager.GetActiveScene().name == "Fase2")
        {
            proximaFase = "Fase3";
            StartCoroutine(MostrarFase(3, "Colina"));
        }
        else if (SceneManager.GetActiveScene().name == "Fase3")
        {
            proximaFase = "Fase4";
            StartCoroutine(MostrarFase(4, "Caverna"));
        }
    }

    IEnumerator MostrarFase(int numeroFase, string nomeFase)
    {
        TelaTransicao.SetActive(true);

        textoFase.text =
            $"ATO {numeroFase}\n\n{nomeFase}";

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(proximaFase);
    }
}