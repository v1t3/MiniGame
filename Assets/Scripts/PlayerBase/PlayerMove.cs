using UnityEngine;

namespace PlayerBase
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private Transform bodyTransform;

        [Header("Movement")]
        [SerializeField] private float moveForce = 1f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float friction = 0.1f;
        [SerializeField] private float forceMultiplierGrounded = 1f;
        [SerializeField] private float forceMultiplierJump = 0.5f;
        public bool grounded;
        private Vector3 _positionBeforeJump;

        [Header("Squat")]
        [SerializeField] private Lifter lifter;
        [SerializeField] private Transform colliderTransform;
        [SerializeField] private float squatRate = 10f;
        [SerializeField] private float squatHeightDelay = 0.5f;
        private Vector3 _targetScale;

        [Header("Look at cursor")]
        [SerializeField] private Transform aimTransform;
        [SerializeField] private float rotateSpeed = 10;
        [SerializeField] private float rotateRate = 60;
        private float _smoothY = 0;

        [Header("Flip")]
        [SerializeField] private float flipSpeed = 10;
        [SerializeField] private float flipDelay = 0.1f;

        private void Update()
        {
            LookOnCursor();

            _targetScale = new Vector3(1, 1, 1);

            if (grounded)
            {
                _positionBeforeJump = transform.position;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
            else
            {
                // Присесть, если высота прыжка больше установленной
                if (Mathf.Abs(transform.position.y - _positionBeforeJump.y) > squatHeightDelay)
                {
                    Seat();
                }
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                Seat();
            }

            colliderTransform.localScale = Vector3.Lerp(
                colliderTransform.localScale,
                _targetScale,
                Time.deltaTime * squatRate
            );
        }

        private void FixedUpdate()
        {
            Move();

            if (grounded)
            {
                lifter.GetUp();
            }
        }

        public void Jump()
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            Invoke(nameof(Flip), flipDelay);
        }

        private void Flip()
        {
            playerRb.freezeRotation = false;
            
            Vector3 lookAt = transform.position - aimTransform.position;
            int direction = (lookAt.x < 0) ? 1 : -1;

            playerRb.AddRelativeTorque(0, 0, flipSpeed * direction, ForceMode.VelocityChange);
        }

        private void Seat()
        {
            _targetScale = new Vector3(1, 0.5f, 1);
        }

        private void LookOnCursor()
        {
            Vector3 lookAt = transform.position - aimTransform.position;
            float targetY = rotateRate;

            if (lookAt.x < 0)
            {
                targetY = -rotateRate;
            }

            _smoothY = Mathf.Lerp(_smoothY, targetY, Time.deltaTime * rotateSpeed);
            bodyTransform.localEulerAngles = new Vector3(0, _smoothY, 0);
        }

        private void OnCollisionStay(Collision other)
        {
            playerRb.freezeRotation = true;
            
            foreach (var contactPoint in other.contacts)
            {
                float angle = Vector3.Angle(contactPoint.normal, Vector3.up);

                if (Mathf.Abs(angle) < 45)
                {
                    grounded = true;
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            grounded = false;
        }

        private void Move()
        {
            float speedMultiplier = forceMultiplierGrounded;

            if (!grounded)
            {
                speedMultiplier = forceMultiplierJump;

                if (
                    (Input.GetAxis("Horizontal") > 0 && playerRb.velocity.x > maxSpeed) ||
                    (Input.GetAxis("Horizontal") < 0 && playerRb.velocity.x < -maxSpeed)
                )
                {
                    speedMultiplier = 0;
                }
            }
            else
            {
                //Friction
                playerRb.AddForce(-playerRb.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
            }

            //Moving
            playerRb.AddForce(
                Input.GetAxis("Horizontal") * moveForce * speedMultiplier,
                0,
                0,
                ForceMode.VelocityChange
            );
        }
    }
}