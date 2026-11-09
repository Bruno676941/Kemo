using UnityEngine;

public class Chave : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventario inventario = other.GetComponent<Inventario>();
            if (inventario != null)
            {
                inventario.Chaves++;
                inventario.AtualizarInventario();
                Destroy(gameObject);
            }
        }
    }


}
