using TMPro;
using UnityEngine;
using System.Collections;
public enum EstadoBatalha
{
    TurnoJogador,
    TurnoInimigo,
    Vitoria,
    Derrota
}

public class SistemaBatalha: MonoBehaviour
{
    public EstadoBatalha estadoAtual;
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
        estadoAtual = EstadoBatalha.TurnoJogador;

    }
    public void Atacar()
    {
        if (estadoAtual != EstadoBatalha.TurnoJogador)
        {
            return;
        }

        InimigoHP -= 5;

        if (InimigoHP <= 0)
        {
            InimigoHPTexto.text = "Voce venceu!";
            estadoAtual = EstadoBatalha.Vitoria;
            BotaoContinuar.SetActive(true);
            return;
        }

        if (PlayerHP <= 0)
        {
            PlayerHPTexto.text = "Game Over";
            estadoAtual = EstadoBatalha.Derrota;
            return;
        }
        AtualizarUI();

        estadoAtual = EstadoBatalha.TurnoInimigo;

        StartCoroutine(AtaqueInimigo());

    }

    IEnumerator AtaqueInimigo()
    {
        yield return new WaitForSeconds(1f);

        PlayerHP -= 5;

        if (PlayerHP <= 0)
        {
            estadoAtual = EstadoBatalha.Derrota;

            PlayerHPTexto.text = "Game Over";

            BotaoContinuar.SetActive(true);

            yield break;
        }

        AtualizarUI();

        estadoAtual = EstadoBatalha.TurnoJogador;
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

