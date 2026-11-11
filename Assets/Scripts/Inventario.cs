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
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TextoInventario =
            GameObject.Find("TextoInventario")
            .GetComponent<TMP_Text>();

        PainelInventario =
            GameObject.Find("PainelInventario");

        AtualizarInventario();
    }
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
