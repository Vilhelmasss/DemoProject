using UnityEngine;

public class DeflectAbility : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Projectile")
        {
            other.transform.eulerAngles = new Vector3(0f, 0f, -other.transform.eulerAngles.z);
        }
    }
}
