using UnityEngine;

public class BattleTrigger : MonoBehaviour

{
    public GameObject PainelBatalha;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PainelBatalha.SetActive(true);
            Debug.Log("Batalha iniciada!");
        }
    }
}