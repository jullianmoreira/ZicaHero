using UnityEngine;
using System.Collections;

public class CharacterMovementAdvancedModel : MonoBehaviour 
{
    public float PushingSpeed;

    CharacterMovementModel m_MovementModel;
    CharacterInteractionModel m_InteractionModel;

    Vector3 m_LastPosition;
    float m_LastPositionTime;
    float m_MovementStartTime;
    bool m_WasMoving;
    Transform m_ClosestPushableParent;
    Collider2D m_Collider;

    void Awake()
    {
        m_MovementModel = GetComponent<CharacterMovementModel>();
        m_InteractionModel = GetComponent<CharacterInteractionModel>();
        m_Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        UpdatePushing();
        UpdateWasMoving();
    }

    void UpdateWasMoving()
    {
        if( m_WasMoving == false && m_MovementModel.IsMoving() == true )
        {
            m_MovementStartTime = Time.realtimeSinceStartup;
        }

        m_WasMoving = m_MovementModel.IsMoving();
    }

    void UpdatePushing()
    {
        Vector3 position = transform.position;

        if( Vector3.Distance( position, m_LastPosition ) > 0.005f )
        {
            m_LastPosition = position;
            m_LastPositionTime = Time.realtimeSinceStartup;
        }
    }

    float GetMovingDuration()
    {
        if( m_MovementModel.IsMoving() == false )
        {
            return 0f;
        }

        return Time.realtimeSinceStartup - m_MovementStartTime;
    }

    float GetTimeInSamePosition()
    {
        return Time.realtimeSinceStartup - m_LastPositionTime;
    }
}
