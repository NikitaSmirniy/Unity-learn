using System;
using UnityEngine;

[Serializable]
public class Health
{
   [SerializeField] private float _value;

   public Health(int maxValue)
   {
      MaxValue = maxValue;
      _value = MaxValue;
   }
   
   public int MaxValue { get; private set; }
   
   public float Value
   {
      get => _value;
      set
      {
         _value = Mathf.Clamp(value, 0f, MaxValue);
      }
   }
}