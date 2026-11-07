using TMPro;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public GameObject PainelLoja;

    private bool jogadorNaLoja;

    public TMP_Text TextoEntradaLoja;

    private void Start()
    {
        TextoEntradaLoja.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entrou na loja");
            TextoEntradaLoja.text = "Bem-vindo à loja!\n Aperte E para abri-la";
            TextoEntradaLoja.gameObject.SetActive(true);
            jogadorNaLoja = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextoEntradaLoja.gameObject.SetActive(false);
            jogadorNaLoja = false;
            PainelLoja.SetActive(false);
        }
    }

    private void Update()
    {
        if (jogadorNaLoja && Input.GetKeyDown(KeyCode.E))
        {
            PainelLoja.SetActive(true);
            TextoEntradaLoja.gameObject.SetActive(false);
        }
    }

}
