using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Explosion") Destroy(this.gameObject);
    }
}
