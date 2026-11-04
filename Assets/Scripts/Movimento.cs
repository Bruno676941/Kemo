using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float VelocidadeMovimento = 5f;
    public float velocidadeCorrida = 20f;
    void Start()
    {

    }
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        float velocidadeAtual = VelocidadeMovimento;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeAtual = velocidadeCorrida; 
        }

        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, movimentoVertical);
        transform.Translate(movimento * velocidadeAtual * Time.deltaTime, Space.World);
    }
}
