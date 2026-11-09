using UnityEngine;

public class Rotacao : MonoBehaviour
{
    public float rotacaoVelocidade = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotacaoVelocidade * Time.deltaTime, 0);
    }
}
