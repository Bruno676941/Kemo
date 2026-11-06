using UnityEngine;

public class Camera : MonoBehaviour
{
    
    public Transform player;

    public Vector3 deslocamento = new Vector3(0f, 5f, -10f);
    public float suavidade = 5f;

    void LateUpdate()
    {
        Vector3 posicaoDesejada = player.position + deslocamento;
        Vector3 posicaoAtual = transform.position;
        posicaoAtual = Vector3.Lerp(posicaoAtual, posicaoDesejada, suavidade * Time.deltaTime);
        transform.position = posicaoAtual;
        transform.LookAt(player);
    }
}
