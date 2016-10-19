using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent( typeof( Character ) )]
public class CharacterInteractionModel : MonoBehaviour
{
    private Character m_Character;
    private Collider2D m_Collider;
    private CharacterMovementModel m_MovementModel;

    void Awake()
    {
        m_Character = GetComponent<Character>();
        m_Collider = GetComponent<Collider2D>();
        m_MovementModel = GetComponent<CharacterMovementModel>();
    }

    public void OnInteract()
    {
        if( IsCarryingObject() == true )
        {
            return;
        }

    }

    public Collider2D[] GetCloseColliders()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        return Physics2D.OverlapAreaAll(
            (Vector2)transform.position + boxCollider.offset + boxCollider.size * 0.6f,
            (Vector2)transform.position + boxCollider.offset - boxCollider.size * 0.6f );
    }

    public bool IsCarryingObject()
    {
		return true;
    }
}
