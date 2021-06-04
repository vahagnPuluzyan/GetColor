using UnityEngine;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class ThirdPersonUserControl : MonoBehaviour
{
        private ThirdPersonCharacter m_Character;
        private Transform m_Cam;               
        private Vector3 m_CamForward;     
        private Vector3 m_Move;
        [HideInInspector] public float h;
        [HideInInspector]public float v;
        
        private void Start()
        {
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void FixedUpdate()
        {
            if (m_Cam != null)
            {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;

            m_Character.Move(m_Move);
        }
}