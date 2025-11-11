using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu(menuName = "Item/Weapon")]//Позволяет создать объект с данным типом при открытии контекстного меню в месте его открытия
[RequireComponent(typeof(Rigidbody))]//При добавлении этого компонента на объект автоматический добавляет указанный компонент на него
public class TestAttributes : MonoBehaviour
{
    [SerializeField] private int _number; //Атрибут для видимости в инспекторе поля с приватным модом
    [HideInInspector] public string Name; //Атрибут для сокрытия в инспекторе поля с публичным модом

    [Range(0, 100)] // типо кастомный редактор для атрибута задает границы для значения в поле
    [SerializeField] protected float health;

    [Header("Title/Заголовок")] //Задаёт подпись над сериализуемым полем в инспекторе
    public int Number;

    [Space] // задаёт отступ в инспекторе
    [SerializeField] private string _name;

    [Tooltip("Tip/Подсказка")] //Задаёт подсказку при наведении на сериализуемое поле
    [SerializeField] private GameObject _gameObject;

    [field: Header("JsonAttributes"), SerializeField]
    [JsonProperty(PropertyName = "n")] public string NameOfPidor { get; private set; }
    //[JsonIgnore] - позволяет указать поле, которое сериализовать не нужно.
}