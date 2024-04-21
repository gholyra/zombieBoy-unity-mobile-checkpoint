using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float zDistance;
    
    private void Update()
    {
        Vector3 playerPoint = target.position;
        playerPoint.y = transform.position.y;
        playerPoint.z = target.position.z - zDistance;
        transform.position = Vector3.Lerp(transform.position, playerPoint, speed * Time.deltaTime);
    }
}
