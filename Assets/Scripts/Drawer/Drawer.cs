using UnityEngine;

namespace Drawer
{
    public class Drawer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private bool _open = false;
        private int _openHash = Animator.StringToHash("Open");
        public void OnMouseUp()
        {
            _open = !_open;
            _animator.SetBool(_openHash, _open);
        }
    }
}