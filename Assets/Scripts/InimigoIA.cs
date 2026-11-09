using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    public Transform player;
    public float velocidade = 3f;
    public float distanciaperseguicao = 5f;

    public SistemaBatalha inimigoHP;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);


        if (distance <= distanciaperseguicao && distance > 1f)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            transform.position = Vector3.MoveTowards(
                transform.position, player.position, velocidade * Time.deltaTime);
        }
      
    }
}
