using UnityEngine;

public class CharacterController2D : MonoBehaviour {
    [SerializeField] private float m_JumpForce = 400f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] private LayerMask m_WhatIsGround;
	[SerializeField] private Transform m_GroundCheck;
	[SerializeField] private Transform m_CeilingCheck;
	[SerializeField] private Collider2D m_CrouchDisableCollider;

    const float k_GroundedRadius = .2f;
	private bool m_Grounded;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;
	private Vector3 velocity = Vector3.zero;
    
    private void Awake() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++){
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
		}
    }

    public void Move(float move, bool crouch, bool jump){
        if(!crouch){
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_GroundedRadius, m_WhatIsGround)){
                crouch = true;
            }
        }

        if(m_Grounded || m_AirControl){
            if(crouch){
                move *= m_CrouchSpeed;
                if(!m_CrouchDisableCollider != null){
                    m_CrouchDisableCollider.enabled = true;
                }
            } else {
                if(m_CrouchDisableCollider != null){
                    m_CrouchDisableCollider.enabled = false;
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

            if(move > 0 && !m_FacingRight){
                Flip();
            }

            if(move < 0 && m_FacingRight){
                Flip();
            }

        }
        if(m_Grounded && jump){
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

    }

    public void Flip(){
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
