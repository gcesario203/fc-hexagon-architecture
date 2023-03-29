using Lib.Shared.Contracts;
using Lib.Shared.Attributes;
using System.Reflection;

namespace Lib.Shared.Abstractions
{
    public class BaseValidator : IValidator
    {
        public IEnumerable<string> GetEmptyRequiredFields()
        {
            var props = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                      .Where(x => x.CustomAttributes
                                                   .Select(k => k.AttributeType)
                                                   .Contains(typeof(RequiredFieldAttribute)
                                            ));

            if (props.Count() == 0)
                yield break;

            foreach (var prop in props)
            {
                var propertyName = ValidateIfPropertyIsNullOrEmpty(prop);

                if (string.IsNullOrEmpty(propertyName))
                    yield break;

                yield return propertyName;
            }
        }

        public virtual (bool isValid, Exception? exception) IsValid()
        {
            var requiredFields = GetEmptyRequiredFields();

            if (requiredFields.Count() > 0)
                return (false, new Exception($"One or more required fields are not filled: {string.Join(',', requiredFields)}"));

            return (true, null);
        }

        private string? ValidateIfPropertyIsNullOrEmpty(FieldInfo prop)
        {
            var propTypeDefaultValue = GetDefaultValueByType(prop.GetType());

            var propValue = prop.GetValue(this);

            if (prop.FieldType.IsClass && (propValue == null || propTypeDefaultValue == propValue))
                return prop.Name;

            if (string.IsNullOrEmpty(propValue?.ToString()) || propTypeDefaultValue?.ToString() == propValue?.ToString())
                return prop.Name;

            return null;
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