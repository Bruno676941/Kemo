using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    public Transform player;

    public float velocidade = 3f;
    public float distanciaPerseguicao = 10f;
    public float distanciaParada = 1.5f;

    void Update()
    {
        float distancia = Vector3.Distance(
            transform.position,
            player.position
        );

        if (distancia <= distanciaPerseguicao &&
            distancia > distanciaParada)
        {
            Vector3 direcao =
                player.position - transform.position;

            // ignora diferença de altura
            direcao.y = 0;

            transform.position +=
                direcao.normalized *
                velocidade *
                Time.deltaTime;

            transform.rotation =
     Quaternion.LookRotation(direcao) *
     Quaternion.Euler(0, 180, 0);
        }
    }
}