using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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

    public TMP_Text TextoTurno;

    public GameObject PainelBatalha;

    public GameObject BotaoContinuar;

    public Button BotaoAtaque;

    public TMP_Text TextoResultado;

    public Inventario inventario;

    void Start()
    {
        AtualizarUI();
    }
    public void IniciarBatalha()
    {
        PlayerHP = 30;
        InimigoHP = 20;

        AtualizarUI();
        TextoResultado.gameObject.SetActive(false);
        BotaoContinuar.SetActive(false);
        estadoAtual = EstadoBatalha.TurnoJogador;
        TextoTurno.text = "Turno do Jogador";
        BotaoAtaque.interactable = true;
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
            
            TextoResultado.text = "VOCE VENCEU!\n+10 moedas";
            estadoAtual = EstadoBatalha.Vitoria;
            inventario.Moedas += 10;
            inventario.AtualizarInventario();
            BotaoContinuar.SetActive(true);
            TextoResultado.gameObject.SetActive(true);
            PlayerHPTexto.gameObject.SetActive(false);
            InimigoHPTexto.gameObject.SetActive(false);
            TextoTurno.gameObject.SetActive(false);
            BotaoAtaque.gameObject.SetActive(false);
            
            return;
        }

        if (PlayerHP <= 0)
        {
            TextoResultado.text = "Game Over";
            estadoAtual = EstadoBatalha.Derrota;
            PlayerHPTexto.gameObject.SetActive(false);
            InimigoHPTexto.gameObject.SetActive(false);
            TextoTurno.gameObject.SetActive(false);
            BotaoAtaque.gameObject.SetActive(false);
            return;
        }
        AtualizarUI();

        estadoAtual = EstadoBatalha.TurnoInimigo;
        TextoTurno.text = "Turno do Inimigo";
        TextoResultado.gameObject.SetActive(true);
        BotaoAtaque.interactable = false;
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
        TextoTurno.text = "Turno do Jogador";
        BotaoAtaque.interactable = true;
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

