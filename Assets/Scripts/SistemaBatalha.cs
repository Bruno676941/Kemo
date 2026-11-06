using TMPro;
using UnityEngine;

public class SistemaBatalha: MonoBehaviour
{

    public int PlayerHP = 30;
    public int InimigoHP = 20;

    public TMP_Text PlayerHPTexto;
    public TMP_Text InimigoHPTexto;

    public GameObject PainelBatalha;

    public GameObject BotaoContinuar;

    void Start()
    {
        AtualizarUI();
    }
    public void IniciarBatalha()
    {
        PlayerHP = 30;
        InimigoHP = 20;

        AtualizarUI();
        BotaoContinuar.SetActive(false);
    }
    public void Atacar()
    {
        InimigoHP -= 10;

        if (InimigoHP <= 0)
        {
            InimigoHPTexto.text = "Voce venceu!";
            BotaoContinuar.SetActive(true);
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
    public void Continuar()
    {
        PainelBatalha.SetActive(false);
    }
    void AtualizarUI()
    {
        PlayerHPTexto.text = "Heroi HP: " + PlayerHP;
        InimigoHPTexto.text = "Slime HP: " + InimigoHP;
    }
}

