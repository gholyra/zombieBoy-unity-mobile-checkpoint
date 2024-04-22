using System.Collections;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    [SerializeField] private float lifeSpan;
    
    private void Start()
    {
        StartCoroutine(LifeSpan());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.pumpkinsCollected++;
            
            Destroy(this.gameObject);
        }
    }
    
    private IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(this.gameObject);
    }
}
