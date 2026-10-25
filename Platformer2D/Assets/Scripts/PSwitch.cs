using UnityEngine;

public enum EPSwitchState : byte
{ 
    Unknown,
    NotPressed,
    Pressed
}
public class PSwitch : Pickup
{
    private Animator animator;
    private BoxCollider2D boxCollider;
    private EPSwitchState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        pickupType = EPickupType.PSwitch;

        SetState(EPSwitchState.NotPressed);

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == EPSwitchState.NotPressed)
        {
            if (collision.gameObject.CompareTag("Mario"))
            {
                // Get the Mario component from the GameObject
                Mario mario = collision.gameObject.GetComponent<Mario>();

                for (int i = 0; i < collision.contactCount; i++)
                {
                    // Variable to hold information for collision to adjust it AFTER it's been pressed.
                    ContactPoint2D contact = collision.GetContact(i);

                    if (contact.normal.y < -0.5f)
                    {
                        SetState(EPSwitchState.Pressed);
                        Game.Instance.OnPSwitchPressed();
                        
                        // Changes the collider to be recognized as a trigger so it doesn't block Mario.
                        boxCollider.isTrigger = true;
                    }
                
                
                }
                // TODO : Add Game Logic
            }
        }
    }

    private void SetState(EPSwitchState newState)
    {
        if (state != newState)
        {
            state = newState;

            if (state == EPSwitchState.Pressed)
            {
                animator.Play("PSwitch-Pressed");
            }
            else if (state == EPSwitchState.NotPressed)
            {
                animator.Play("PSwitch-NotPressed");
            }
        }
    }
}
