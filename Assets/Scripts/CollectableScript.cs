using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    [SerializeField] private float lifeSpan;

    private void Awake()
    {

    }

    private void Start()
    {
        StartCoroutine(LifeSpan());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SoundManager.Instance.PlayMyAudioClip(1,1, false);
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
