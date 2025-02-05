using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
}
