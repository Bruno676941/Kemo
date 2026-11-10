using UnityEngine;

public class Chave : MonoBehaviour
{
   public Inventario inventario;
    private void OnTriggerEnter(Collider other)
    {
    
        Debug.Log("Colidiu com: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pegou a chave");
            inventario.Chaves++;
                inventario.AtualizarInventario();
                Destroy(gameObject);
            
        }
    }


}
