using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int PlayerHP;

    public int iniciativa;
    public Transform Jogador;
    public Vector3 PosicaoAnteriorJogador;
    public Vector3 PosicaoAnteriorInimigo;
    public TMP_Text PlayerHPTexto;
    public TMP_Text InimigoHPTexto;

    public TMP_Text TextoTurno;
    public TMP_Text TextoPocoes;

    public GameObject PainelBatalha;

    public GameObject BotaoContinuar;

    public Button BotaoAtaque;

    public Button BotaoItem;

    public TMP_Text TextoResultado;
    public Inventario inventario;

    public Movimento movimentoJogador;
    

    public List<Inimigo> inimigos = new List<Inimigo>();
    private Inimigo inimigoAtual;
    private GameObject inimigoObjetoAtual;

    public StatusJogador statusJogador;

    public GameObject PainelItem;
    public GameObject PainelGameOver;
    void Start()
    {
        AtualizarUI();
        statusJogador.InicializarStatus();
        PlayerHP = statusJogador.vida;
        PainelGameOver.SetActive(false);
        AtualizarUI();
    }
    public void IniciarBatalha()
    {
        Debug.Log("BATALHA INICIADA: " + inimigoAtual.Nome);
        PosicaoAnteriorJogador = movimentoJogador.transform.position;
        PosicaoAnteriorInimigo = inimigoObjetoAtual.transform.position;
        Vector3 direcao =(inimigoObjetoAtual.transform.position - Jogador.position).normalized;

        direcao.y = 0;
        Jogador.position -= direcao * 2f;

       inimigoObjetoAtual.transform.position += direcao * 2f;



        inimigoObjetoAtual.GetComponent<InimigoIA>();
            if (inimigoObjetoAtual.GetComponent<InimigoIA>() != null)
        {
            inimigoObjetoAtual.GetComponent<InimigoIA>().enabled = false;
        }

        Jogador.LookAt(inimigoObjetoAtual.transform);

        Vector3 rotacao = Jogador.eulerAngles;
        Jogador.rotation = Quaternion.Euler(0, rotacao.y, 0);
        inimigoObjetoAtual.transform.LookAt(Jogador.transform);
        if (SceneManager.GetActiveScene().name == "Fase2" )
        {
            inimigoObjetoAtual.transform.Rotate(0, 90, 0);
        }
        else if (SceneManager.GetActiveScene().name == "Fase4")
        {
            inimigoObjetoAtual.transform.Rotate(0, 90, 20);
        }


        inimigoAtual.HP = inimigoAtual.HPMax;
        AtualizarUI();
        PainelBatalha.SetActive(true);
        PlayerHPTexto.gameObject.SetActive(true);
        InimigoHPTexto.gameObject.SetActive(true);
        TextoTurno.gameObject.SetActive(true);
        BotaoAtaque.gameObject.SetActive(true);
        TextoResultado.gameObject.SetActive(false);
        BotaoContinuar.SetActive(false);
        BotaoItem.gameObject.SetActive(true);
        DefinirPrimeiroTurno();
        movimentoJogador.enabled = false;


    }
    public void Atacar()
    {
        Debug.Log("Clique recebido");
        Debug.Log(estadoAtual);
        if (estadoAtual != EstadoBatalha.TurnoJogador)
        {
            return;
        }

        inimigoAtual.HP -= statusJogador.dano;
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
            BotaoItem.gameObject.SetActive(false);
            movimentoJogador.enabled = true;
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
            BotaoItem.gameObject.SetActive(false);
            movimentoJogador.enabled = true;
            return;
        }
        AtualizarUI();

        estadoAtual = EstadoBatalha.TurnoInimigo;
        TextoTurno.text = "Turno do Inimigo";
        TextoResultado.gameObject.SetActive(true);
        BotaoAtaque.interactable = false;
        BotaoItem.interactable = false;
        StartCoroutine(AtaqueInimigo());

    }
    void DefinirPrimeiroTurno()
    {
        int iniciativaJogador = statusJogador.iniciativa;
        int iniciativaInimigo = inimigoAtual.iniciativa;

        if (iniciativaJogador > iniciativaInimigo)
        {
            estadoAtual = EstadoBatalha.TurnoJogador;
        }
        else if (iniciativaInimigo > iniciativaJogador)
        {
            estadoAtual = EstadoBatalha.TurnoInimigo;
        }
        else
        {
            int resultado = UnityEngine.Random.Range(1, 3);

            if (resultado == 1)
            {
                estadoAtual = EstadoBatalha.TurnoInimigo;
            }
            else
            {
                estadoAtual = EstadoBatalha.TurnoJogador;
            }
        }

        if (estadoAtual == EstadoBatalha.TurnoJogador)
        {
            TextoTurno.text = "Turno do Jogador";

            BotaoAtaque.interactable = true;
            BotaoItem.interactable = true;
        }
        else
        {
            TextoTurno.text = "Turno do Inimigo";

            BotaoAtaque.interactable = false;
            BotaoItem.interactable = false;

            StartCoroutine(AtaqueInimigo());
        }
    }
    IEnumerator AtaqueInimigo()
    {
        TextoResultado.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        PlayerHP -= inimigoAtual.Dano;

        if (PlayerHP <= 0)
        {
            estadoAtual = EstadoBatalha.Derrota;

            PlayerHPTexto.text = "Game Over";

            BotaoContinuar.SetActive(false);

            PainelGameOver.SetActive(true);

            yield break;
        }

        AtualizarUI();

        TextoResultado.gameObject.SetActive(false);
        estadoAtual = EstadoBatalha.TurnoJogador;
        TextoTurno.text = "Turno do Jogador";
        BotaoAtaque.interactable = true;
        BotaoItem.interactable = true;
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
    public void Continuar()
    {
        if (SceneManager.GetActiveScene().name == "Fase1" || SceneManager.GetActiveScene().name == "Fase4")
        {
            Jogador.position =
    PosicaoAnteriorJogador + Vector3.up * 1f;
        }
        else
            Jogador.position = PosicaoAnteriorJogador;
        
        PainelBatalha.SetActive(false);
     }
    void AtualizarUI()
    {
        PlayerHPTexto.text = "Heroi HP: " + PlayerHP;
        
        if (inimigoAtual != null)
        {
            InimigoHPTexto.text = inimigoAtual.Nome + " HP: " + inimigoAtual.HP;
        }
    }
    public void definirInimigo(string Nome, GameObject objeto)
    {
        
        inimigoAtual = inimigos.Find(inimigo => inimigo.Nome == Nome);
        inimigoObjetoAtual = objeto;
    }
    public void AbrirItens()
    {
        PainelItem.SetActive(true);
        BotaoAtaque.gameObject.SetActive(false);
        BotaoItem.gameObject.SetActive(false);
        PlayerHPTexto.gameObject.SetActive(false);
        InimigoHPTexto.gameObject.SetActive(false);
        TextoTurno.gameObject.SetActive(false);
        TextoPocoes.text =
    "Pocoes: " + inventario.Pocoes;
    }
    public void FecharItens()
    {
        PainelItem.SetActive(false);
        PainelBatalha.SetActive(true);
        BotaoAtaque.gameObject.SetActive(true);
        BotaoItem.gameObject.SetActive(true);
        TextoTurno.gameObject.SetActive(true);
        PlayerHPTexto.gameObject.SetActive(true);
        InimigoHPTexto.gameObject.SetActive(true);
    }
    public void UsarPocao()
    {
        if (estadoAtual != EstadoBatalha.TurnoJogador)
        {
            return;
        }
        if (inventario.Pocoes > 0)
        {
            PlayerHP += 10;
            inventario.Pocoes -= 1;
            inventario.AtualizarInventario();
            AtualizarUI();
            estadoAtual = EstadoBatalha.TurnoInimigo;
            TextoTurno.text = "Turno do Inimigo";
            BotaoAtaque.interactable = false;
            BotaoItem.interactable = false;
            PainelItem.SetActive(false);
            PainelBatalha.SetActive(true);
            BotaoAtaque.gameObject.SetActive(true);
            BotaoItem.gameObject.SetActive(true);
            TextoTurno.gameObject.SetActive(true);
            PlayerHPTexto.gameObject.SetActive(true);
            InimigoHPTexto.gameObject.SetActive(true);
            StartCoroutine(AtaqueInimigo());
        }
    }

}

