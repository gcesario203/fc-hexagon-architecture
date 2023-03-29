using Lib.Shared.Contracts;
using Lib.Shared.Attributes;
using System.Reflection;

namespace Lib.Shared.Abstractions
{
    public class BaseValidator : IValidator
    {
        public IEnumerable<string> GetEmptyRequiredFields()
        {
            var props = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.CustomAttributes.Select(k => k.AttributeType).Contains(typeof(RequiredFieldAttribute)));

            if (props.Count() == 0)
                return new List<string>();

            var requiredFields = new List<string>();

            foreach (var prop in props)
            {
                var propTypeDefaultValue = GetDefaultValueByType(prop.GetType());

                var propValue = prop.GetValue(this);

                if (prop.FieldType.IsClass && (propValue == null || propTypeDefaultValue == propValue))
                    requiredFields.Add(prop.Name);
                else if (string.IsNullOrEmpty(propValue?.ToString()) || propTypeDefaultValue?.ToString() == propValue?.ToString())
                    requiredFields.Add(prop.Name);
            }

            return requiredFields;
        }

        public virtual (bool isValid, Exception? exception) IsValid()
        {
            var requiredFields = GetEmptyRequiredFields();

            if (requiredFields.Count() > 0)
                return (false, new Exception($"One or more required fields are not filled: {string.Join(',', requiredFields)}"));

            return (true, null);
        }

        private object GetDefaultValueByType(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}