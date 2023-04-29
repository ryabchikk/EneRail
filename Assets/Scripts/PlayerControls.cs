using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Vector3 LastDirection { get; private set; }
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
        
        if(direction == Vector3.zero)
            return;

        LastDirection = direction;

        var target = player.GetTargetAt(direction);
        if (target != null)
        {
            player.MoveTo(target);
        }
    }
}
