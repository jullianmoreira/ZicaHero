﻿using UnityEngine;
using System.Collections;

public class CharacterAnimationListener : MonoBehaviour
{
    public CharacterMovementModel MovementModel;
    public CharacterMovementView MovementView;

    public void OnAttackStarted( AnimationEvent animationEvent )
    {
        if( MovementModel != null )
        {
            MovementModel.OnAttackStarted();
        }

        if( MovementView != null )
        {
            MovementView.OnAttackStarted();
        }

        ShowWeapon();
        SetSortingOrderOfWeapon( animationEvent.intParameter );
    }

    public void OnAttackFinished()
    {
        if( MovementModel != null )
        {
            MovementModel.OnAttackFinished();
        }

        if( MovementView != null )
        {
            MovementView.OnAttackFinished();
        }

        HideWeapon();
    }

    public void ShowWeapon()
    {
        if( MovementView != null )
        {
            MovementView.ShowWeapon();
        }
    }

    public void HideWeapon()
    {
        if( MovementView != null )
        {
            MovementView.HideWeapon();
        }
    }

    public void SetSortingOrderOfWeapon( int sortingOrder )
    {
        if( MovementView != null )
        {
            MovementView.SetSortingOrderOfWeapon( sortingOrder );
        }
    }

    public void SetSortingOrderOfPickupItem( int sortingOrder )
    {
        if( MovementView != null )
        {
            MovementView.SetSortingOrderOfPickupItem( sortingOrder );
        }
    }	   
}
