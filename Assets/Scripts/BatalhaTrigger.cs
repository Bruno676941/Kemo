using UnityEngine;

public class BattleTrigger : MonoBehaviour

{
    public GameObject PainelBatalha;
    public SistemaBatalha sistemaBatalha;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sistemaBatalha.definirInimigo(gameObject.name, gameObject);
            Debug.Log("TOCOU NO " + gameObject.name);
            PainelBatalha.SetActive(true);
            sistemaBatalha.IniciarBatalha();
}

    }
}