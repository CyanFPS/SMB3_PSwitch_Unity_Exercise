using UnityEngine;

public class CoinPickup : Pickup
{
    private Animator animator;
    private bool isCoinStatic = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupType = EPickupType.Coin;
        animator = GetComponent<Animator>();
        
        if (animator != null &&!isCoinStatic)
        {
            animator.Play("CoinPickup");
        }

        if (animator != null && isCoinStatic)
        {
            animator.enabled = false; // Disabling the animator
        }
        
    }

    public void UseStaticCoin()
    {
        isCoinStatic = true;
    }
}
