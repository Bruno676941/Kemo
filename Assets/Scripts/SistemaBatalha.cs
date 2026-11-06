using TMPro;
using UnityEngine;

public class SistemaBatalha: MonoBehaviour
{

    public int PlayerHP = 30;
    public int InimigoHP = 20;

    public TMP_Text PlayerHPTexto;
    public TMP_Text InimigoHPTexto;

    void Start()
    {
        AtualizarUI();
    }

    public void Atacar()
    {
        InimigoHP -= 10;

        if (InimigoHP <= 0)
        {
            InimigoHPTexto.text = "Voce venceu!";
            return;
        }

        PlayerHP -= 5;

        if (PlayerHP <= 0)
        {
            PlayerHPTexto.text = "Game Over";
            return;
        }

        AtualizarUI();
    }

    void AtualizarUI()
    {
        PlayerHPTexto.text = "Heroi HP: " + PlayerHP;
        InimigoHPTexto.text = "Slime HP: " + InimigoHP;
    }
}

