using UnityEngine;

public class Chave : MonoBehaviour
{
   public Inventario inventario;
    private void OnTriggerEnter(Collider other)
    {
    
        
        if (other.CompareTag("Player"))
        {
                inventario.Chaves++;
                inventario.AtualizarInventario();
                Destroy(gameObject);
            
        }
    }


}
