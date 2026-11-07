using TMPro;
using UnityEngine;

public class Inventario : MonoBehaviour
{
        public int Chaves;
        public int Pocoes;
        public TMP_Text TextoInventario;
        public GameObject PainelInventario;
    public void AtualizarInventario()
    {
        TextoInventario.text =
            "Inventário\n\n" +
            "Chaves: " + Chaves +
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
