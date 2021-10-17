using PlayerBase;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

namespace WeaponBase
{
    public class RopeGun : MonoBehaviour
    {
        [SerializeField] private RopeRenderer ropeRenderer;
        [SerializeField] private Hook hook;
        [SerializeField] private Transform spawn;
        [SerializeField] private float speed;
        [SerializeField] private float springValue = 50;
        [SerializeField] private float damperValue = 5;

        [SerializeField] private Transform ropeStart;
        [SerializeField] private float maxRopeDistance = 20;
        
        [SerializeField] private PlayerMove playerMove;
        
        private SpringJoint _springJoint;
        private float _ropeLength;
        private RopeState _currentRopeState;

        private void Update()
        {
            if (Input.GetMouseButtonDown(2))
            {
                Shot();
            }

            if (_currentRopeState == RopeState.Fly)
            {
                var distance = Vector3.Distance(ropeStart.position, hook.transform.position);

                if (distance > maxRopeDistance)
                {
                    DisableRope();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!playerMove.grounded && _currentRopeState == RopeState.Active)
                {
                    playerMove.Jump();
                }
                
                DisableRope();
            }

            if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active)
            {
                ropeRenderer.Draw(ropeStart.position, hook.transform.position, _ropeLength);
            }
        }

        private void Shot()
        {
            DisableRope();
            _ropeLength = 1f;
            hook.gameObject.SetActive(true);
            hook.StopFix();
            hook.transform.position = spawn.position;
            hook.transform.rotation = spawn.rotation;
            hook.selfRigidbody.velocity = spawn.forward * speed;

            _currentRopeState = RopeState.Fly;
        }

        public void CreateSpring()
        {
            if (!_springJoint)
            {
                _springJoint = gameObject.AddComponent<SpringJoint>();
                _springJoint.connectedBody = hook.selfRigidbody;
                _springJoint.anchor = ropeStart.localPosition;
                _springJoint.autoConfigureConnectedAnchor = false;
                _springJoint.connectedAnchor = Vector3.zero;
                _springJoint.spring = springValue;
                _springJoint.damper = damperValue;

                _ropeLength = Vector3.Distance(ropeStart.position, hook.transform.position);
                _springJoint.maxDistance = _ropeLength;

                _currentRopeState = RopeState.Active;
            }
        }

        public void DisableRope()
        {
            if (_springJoint)
            {
                Destroy(_springJoint);
            }
            
            ropeRenderer.Hide();
            hook.gameObject.SetActive(false);
            _currentRopeState = RopeState.Disabled;
        }
    }
}