using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Update()
    {
        if (player.IsMoving)
            return;

        var direction = Vector3.zero;
        
        if (Input.GetKeyDown(KeyCode.W))
            direction = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.A))
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D))
            direction = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.S))
            direction = Vector3.back;

        if (Physics.Raycast(transform.position + direction, direction, out var hit) && hit.collider.gameObject.CompareTag("Target"))
        {
            player.Move(hit.transform);
        }
    }
}
