using UnityEngine;

namespace Helpers.Player
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheckPoint;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private Color hitColor;
        [SerializeField] private Color noHitColor;
        public bool IsGrounded { get; private set; }

        private void Update()
        {
            IsGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
            Debug.Log(IsGrounded);
        }

        private void OnDrawGizmos()
        {
            var checkPosition = groundCheckPoint.position;
            var colliders = Physics2D.OverlapCircleAll(checkPosition, groundCheckRadius, groundLayer);
            Gizmos.color = colliders.Length > 0 ? hitColor : noHitColor;
            Gizmos.DrawWireSphere(checkPosition, groundCheckRadius);
        }
    }
}