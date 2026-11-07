using TMPro;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public GameObject PainelLoja;

    private bool jogadorNaLoja;

    public TMP_Text TextoEntradaLoja;

    public Inventario inventario;

    public TMP_Text TextoMoedasLoja;

    private void Start()
    {
        TextoEntradaLoja.gameObject.SetActive(false);
    }
    void AtualizarLoja()
    {
        TextoMoedasLoja.text =
            "Moedas: " + inventario.Moedas;
    }

    public void ComprarPocao()
    {
        if (inventario.Moedas >= 10)
        {
            inventario.Moedas -= 10;
            inventario.Pocoes += 1;

            inventario.AtualizarInventario();
            AtualizarLoja();
        }
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
            AtualizarLoja();
        }
    }

}
