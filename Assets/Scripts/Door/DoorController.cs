using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Parte móvil de la puerta")]
    public Transform door;             // La parte que se mueve 

    [Header("Configuración Corredera")]
    public Vector3 closedLocalPos;     // Posición cerrada
    public Vector3 openLocalPos = Vector3.right * 2f; // Se mueve 2 metros a la derecha
    public float speed = 2f;           // Velocidad de deslizamiento

    [Header("Configuración Collider")]
    public Collider doorCollider;      // Collider de la puerta

    [HideInInspector]
    public float t;  // 0 = cerrada, 1 = abierta

    void Start()
    {
        // Buscar automáticamente el collider si no está asignado
        if (doorCollider == null && door != null)
        {
            doorCollider = door.GetComponent<Collider>();
            if (doorCollider == null)
            {
                doorCollider = GetComponent<Collider>();
            }
        }
    }

    void Reset()
    {
        if (transform.childCount > 0)
            door = transform.GetChild(0);

        if (door != null)
        {
            closedLocalPos = door.localPosition;
            openLocalPos = closedLocalPos + Vector3.right * 2f; // Abre hacia la derecha
        }
    }

    public void OpenStep()
    {
        t = Mathf.Clamp01(t + speed * Time.deltaTime);
        UpdateDoorPosition();
    }

    public void CloseStep()
    {
        t = Mathf.Clamp01(t - speed * Time.deltaTime);
        UpdateDoorPosition();
    }

    private void UpdateDoorPosition()
    {
        if (door != null)
        {
            // Mover la puerta visualmente
            door.localPosition = Vector3.Lerp(closedLocalPos, openLocalPos, t);

            // Mover el collider con la puerta
            if (doorCollider != null)
            {
                
                
                doorCollider.enabled = (t < 0.9f); // Se desactiva al 90% de apertura
            }
        }
    }

    public bool IsFullyOpen()
    {
        return Mathf.Approximately(t, 1f);
    }

    public bool IsFullyClosed()
    {
        return Mathf.Approximately(t, 0f);
    }

    // Para debug en el editor
    void OnDrawGizmosSelected()
    {
        if (door != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.TransformPoint(closedLocalPos), Vector3.one * 0.3f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.TransformPoint(openLocalPos), Vector3.one * 0.3f);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.TransformPoint(closedLocalPos), transform.TransformPoint(openLocalPos));
        }
    }
}