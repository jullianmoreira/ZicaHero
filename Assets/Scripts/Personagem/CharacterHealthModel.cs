using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterHealthModel : MonoBehaviour 
{
    public float StartingHealth;
    
    private float m_MaximumHealth;
    private float m_Health;

    void Start()
    {
        m_Health = StartingHealth;
        m_MaximumHealth = StartingHealth;
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.T ) )
        {
            DealDamage( 10 );
        }
    }

    public float GetHealth()
    {
        return m_Health;
    }

    public float GetMaximumHealth()
    {
        return m_MaximumHealth;
    }

    public float GetHealthPercentage()
    {
        return m_Health / m_MaximumHealth;
    }

    public void DealDamage( float damage )
    {
        if( m_Health <= 0 )
        {
            return;
        }        

        float healthDamage = damage;
        float damageAbsorbedByArmor = 0;
        float totalDamageToAbsorb = damage * 0.5f;
      
        healthDamage -= damageAbsorbedByArmor;
        m_Health -= healthDamage;

        if( m_Health <= 0 )
        {
            m_Health = 0;
            Debug.Log( "Zicado!" );
        }
    }
}
