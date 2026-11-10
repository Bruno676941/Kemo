using UnityEngine;

public class BattleTrigger : MonoBehaviour

{
    public GameObject PainelBatalha;
    public SistemaBatalha sistemaBatalha;
    public SistemaBatalha definirInimigo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sistemaBatalha.definirInimigo(gameObject.name,gameObject);

            PainelBatalha.SetActive(true);
            sistemaBatalha.IniciarBatalha();
}
    }

}