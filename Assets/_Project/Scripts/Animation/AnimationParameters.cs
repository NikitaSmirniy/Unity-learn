using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationParameters
{
    public class  PlayerAnimations
    {
        public readonly int IdleParameters = Animator.StringToHash("Idle");
        public readonly int RunParameters =  Animator.StringToHash("Run");
        public readonly int JumpParameters =  Animator.StringToHash("Jump");
    }
}
