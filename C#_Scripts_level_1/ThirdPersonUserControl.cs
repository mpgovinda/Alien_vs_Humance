using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
//namespace UnityStandardAssets.Characters.ThirdPerson
//{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
	//public static ThirdPersonUserControl control;
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
		public VirtualJoystick joystick;
	public Vector3 start=new Vector3(40.3f, 0f, -13f);
	public Quaternion startRotation = Quaternion.Euler(0,180,0);
	//public GameObject Actions;
	//public Button crouchBtn;
	//public Button jumpBtn;





        private void Start()
        {

//		if (GlobalControl.Instance.playerLocation.) {
//			transform.position = GlobalControl.Instance.playerLocation;
//		} else {
//			transform.position = start;
//		}
//
//		if (GlobalControl.Instance.playerRotation) {
//			transform.rotation = GlobalControl.Instance.playerRotation;
//		} else {
//			transform.rotation = startRotation;
//		}
			
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )

            m_Character = GetComponent<ThirdPersonCharacter>();
		//if (control == null) {
		//	DontDestroyOnLoad (gameObject);
		//	control = this;
		//} else if (control != this) 
		//	{
		//	Destroy (gameObject);
		//	}
        }


        private void Update()
        {
		//if(Input.GetButton(ThirdPersonUserControl.jump))
			
            if (!m_Jump)
            {
                m_Jump = Input.GetButtonDown("Jump");
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
           // float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            float h= joystick.Horizontal();
            float v=joystick.Vertical();
		bool crouch = Input.GetKey(KeyCode.C) ;

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }


    }
//}
