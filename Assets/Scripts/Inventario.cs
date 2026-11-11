using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventario : MonoBehaviour
{
        public int Chaves;
        public int Pocoes;
        public TMP_Text TextoInventario;
        public GameObject PainelInventario;
        public int Moedas;

    public GameObject GerenciadorJogo;
    public void AtualizarInventario()
    {
        TextoInventario.text =
            "Inventário \n" +
            "\nMoedas: " + Moedas +
            "\nChaves: " + Chaves +
            "\nPoções: " + Pocoes;
    }

    void Start()
    {
        AtualizarInventario();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PainelInventario.SetActive(
                !PainelInventario.activeSelf
            );
        }
    }
}
