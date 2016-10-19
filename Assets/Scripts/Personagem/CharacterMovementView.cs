using UnityEngine;
using System.Collections;

public class CharacterMovementView : MonoBehaviour
{
    public enum ShieldDirection
    {
        Front,
        Right,
        Left,
        Back,
        FrontHalf,
        BackHalf,
    }

    public Animator Animator;

    private CharacterMovementModel m_MovementModel;

    void Awake()
    {
        m_MovementModel = GetComponent<CharacterMovementModel>();

        if( Animator == null )
        {
            Debug.LogError( "Character Animator is not setup!" );
            enabled = false;
        }
    }

    void Start()
    {
        SetItemActive( m_MovementModel.WeaponParent, false );
    }

    public void Update() 
    {
        UpdateDirection();   
        UpdateHit();
    }

    void UpdateHit()
    {
        //Animator.SetBool( "IsHit", m_MovementModel.IsBeingPushed() );
    }

    void UpdateDirection()
    {
        Vector3 direction = m_MovementModel.GetFacingDirection();

        if( direction != Vector3.zero )
        {
            if( direction.x != 1 || direction.y != 1 )
            {
                Animator.SetFloat( "Direcao X", direction.x );
                Animator.SetFloat( "Direcao Y", direction.y );
            }
        }

        Animator.SetBool( "Andando", m_MovementModel.IsMoving() );
    }

    public void DoAttack()
    {
        Animator.SetTrigger( "Atacar" );
    }

    public void OnAttackStarted()
    {
        
    }

    public void OnAttackFinished()
    {
        
    }

    public void ShowWeapon()
    {
        SetItemActive( m_MovementModel.WeaponParent, true );
    }

    public void HideWeapon()
    {
        SetItemActive( m_MovementModel.WeaponParent, false );
    }

    public void SetSortingOrderOfWeapon( int sortingOrder )
    {
        SetSortingOrderOfItem( m_MovementModel.WeaponParent, sortingOrder );
    }

    public void SetSortingOrderOfPickupItem( int sortingOrder )
    {
        SetSortingOrderOfItem( m_MovementModel.PickupItemParent, sortingOrder );
    }

    public void ShowShield()
    {
        SetItemActive( m_MovementModel.ShieldParent, true );
    }

    public void HideShield()
    {
        SetItemActive( m_MovementModel.ShieldParent, true );
    }

    public void SetSortingOrderOfShield( int sortingOrder )
    {
        SetSortingOrderOfItem( m_MovementModel.ShieldParent, sortingOrder );
    }

    void SetSortingOrderOfItem( Transform itemParent, int sortingOrder )
    {
        if( itemParent == null )
        {
            return;
        }

        SpriteRenderer[] spriteRenderers = itemParent.GetComponentsInChildren<SpriteRenderer>();

        foreach( SpriteRenderer spriteRenderer in spriteRenderers )
        {
            spriteRenderer.sortingOrder = sortingOrder;
        }
    }

    void SetItemActive( Transform itemParent, bool doActivate )
    {
        if( itemParent == null )
        {
            return;
        }

        itemParent.gameObject.SetActive( doActivate );
    }
}
