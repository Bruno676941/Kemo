using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Batalha iniciada!");
        }
    }
}