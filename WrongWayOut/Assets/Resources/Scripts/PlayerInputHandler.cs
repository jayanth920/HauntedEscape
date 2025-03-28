
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerNew1 player;
    public Transform cameraTransform; // Reference to the FPS camera




    void Update()
    {
        // Instead of using cameraTransform, use the player's transform to determine movement
        Vector3 playerForward = player.transform.forward;
        playerForward.y = 0; // Keep movement grounded

        Vector3 playerRight = player.transform.right;
        playerRight.y = 0; // Keep movement grounded

        Vector3 finalMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            finalMovement += playerForward;

        if (Input.GetKey(KeyCode.A))
            finalMovement -= playerRight;

        if (Input.GetKey(KeyCode.S))
            finalMovement -= playerForward;

        if (Input.GetKey(KeyCode.D))
            finalMovement += playerRight;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            player.playerSpeed = 9f;  // Increase speed when Shift is pressed
        }
        else
        {
            player.playerSpeed = 7f; // Reset to default speed when Shift is not pressed
        }

        finalMovement.Normalize();

        player.MoveWithCC(finalMovement);

        // Used for resetting during development
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}