using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController controller;

    public Transform Player;
    public Transform CameraTransform;

    public float VelocidadeMovimento = 5f;
    public float VelocidadeCorrida = 8f;
    public float ForcaPulo = 7f;
    public float Gravidade = -9.81f;
    public float suavidadeRotacao = 5f;

    private float VelocidadeY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        float velocidadeAtual = Input.GetKey(KeyCode.LeftShift)
            ? VelocidadeCorrida
            : VelocidadeMovimento;

        Vector3 frenteCamera = CameraTransform.forward;
        Vector3 direitaCamera = CameraTransform.right;

        frenteCamera.y = 0;
        direitaCamera.y = 0;

        frenteCamera.Normalize();
        direitaCamera.Normalize();

        Vector3 direcao =
            frenteCamera * movimentoVertical +
            direitaCamera * movimentoHorizontal;

        if (controller.isGrounded)
        {
            VelocidadeY = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                VelocidadeY = ForcaPulo;
            }
        }

        VelocidadeY += Gravidade * Time.deltaTime;

        Vector3 movimento =
            direcao.normalized * velocidadeAtual;

        movimento.y = VelocidadeY;

        controller.Move(movimento * Time.deltaTime);

        if (direcao.magnitude > 0.1f)
        {
            Quaternion rotacaoDesejada =
                Quaternion.LookRotation(direcao);

            Player.rotation = Quaternion.Slerp(
                Player.rotation,
                rotacaoDesejada,
                suavidadeRotacao * Time.deltaTime
            );
        }
    }
}