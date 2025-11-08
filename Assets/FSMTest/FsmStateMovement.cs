using UnityEngine;

namespace FSMTest
{
    public class FsmStateMovement : FsmState, IUpdatebleState
    {
        protected readonly Transform Transform;
        protected readonly float Speed;

        public FsmStateMovement(IFsm fsm, Transform transform, float speed) : base(fsm)
        {
            Transform = transform;
            Speed = speed;
        }

        public virtual void Update()
        {
            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
                _fsm.SetState<FsmStateIdle>();

            Move(inputDirection);
        }

        protected Vector2 ReadInput()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            var inputDirection = new Vector2(inputHorizontal, inputVertical);

            return inputDirection;
        }

        protected virtual void Move(Vector2 inputDirection)
        {
            Transform.position += new Vector3(inputDirection.x, 0f, inputDirection.y) * (Speed * Time.deltaTime);
        }
    }
}