using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    public TMP_Text PlayerHPTexto;
    public TMP_Text InimigoHPTexto;

    public TMP_Text TextoTurno;

    public GameObject PainelBatalha;

    public GameObject BotaoContinuar;

    public Button BotaoAtaque;

    public TMP_Text TextoResultado;
    public Inventario inventario;

    public List<Inimigo> inimigos = new List<Inimigo>();
    private Inimigo inimigoAtual;
    private GameObject inimigoObjetoAtual;
    void Start()
    {
        AtualizarUI();
    }
    public void IniciarBatalha()
    {
        Debug.Log("BATALHA INICIADA: " + inimigoAtual.Nome);
        PlayerHP = 30;

        AtualizarUI();
        PainelBatalha.SetActive(true);
        PlayerHPTexto.gameObject.SetActive(true);
        InimigoHPTexto.gameObject.SetActive(true);
        TextoTurno.gameObject.SetActive(true);
        BotaoAtaque.gameObject.SetActive(true);
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

        inimigoAtual.HP -= 5;
        AtualizarUI();
        if (inimigoAtual.HP <= 0)
        {

            Destroy(inimigoObjetoAtual);
            TextoResultado.text = "Voce venceu!";
            estadoAtual = EstadoBatalha.Vitoria;
            
            TextoResultado.text = "VOCE VENCEU!\n+" + inimigoAtual.Recompensa + " moedas";
            estadoAtual = EstadoBatalha.Vitoria;
            inventario.Moedas += inimigoAtual.Recompensa;
            inventario.AtualizarInventario();
            BotaoContinuar.SetActive(true);
            TextoResultado.gameObject.SetActive(true);
            BotaoContinuar.SetActive(true);
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

        PlayerHP -= inimigoAtual.Dano;

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
        InimigoHPTexto.text = inimigoAtual.Nome + " HP: " + inimigoAtual.HP;
    }
    public void definirInimigo(string Nome, GameObject objeto)
    {
        inimigoAtual = inimigos.Find(inimigo => inimigo.Nome == Nome);
        inimigoObjetoAtual = objeto;
    }
}

