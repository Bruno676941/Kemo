using Unity.InferenceEngine;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class Movimento : MonoBehaviour
{
    private CharacterController controller;
    public Transform Player;
    public float VelocidadeMovimento = 5f;
    public float VelocidadeCorrida = 20f;
    public float ForcaPulo = 7f;
    public float Gravidade = -9.81f;
    private float VelocidadeY;
    public float alturaDoChao = 1f;
    public float suavidadeRotacao = 5f;
    void Start()
    {
     controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(movimentoHorizontal, 0f, movimentoVertical).normalized;

        float velocidadeAtual = VelocidadeMovimento;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeAtual = VelocidadeCorrida; 
        }

        VelocidadeY += Gravidade * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= alturaDoChao + 0.05f)
        {
            VelocidadeY = ForcaPulo;
        }

        if (transform.position.y < alturaDoChao)
        {
            transform.position = new Vector3(transform.position.x, alturaDoChao, transform.position.z);
            VelocidadeY = 0f;
        }
        Vector3 movimento = new Vector3(movimentoHorizontal * velocidadeAtual, VelocidadeY, movimentoVertical * velocidadeAtual);
        controller.Move(movimento * Time.deltaTime);

        if (direcao.sqrMagnitude >= 0.01f)
        {
            Quaternion rotacaoDesejada = Quaternion.LookRotation(direcao);

            Player.rotation = Quaternion.Slerp(Player.rotation, rotacaoDesejada, suavidadeRotacao * Time.deltaTime);
        }
    }
}


