using EventFlow.Exceptions;
using EventFlow.Extensions;
using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Assesment.Domain
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Name : SingleValueObject<string>
    {
        public Name(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= 4)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Street : SingleValueObject<string>
    {
        public Street(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= 4)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class City : SingleValueObject<string>
    {
        public City(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= 4)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class CountryCode3 : SingleValueObject<string>
    {
        public CountryCode3(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 3)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class ZipCode : SingleValueObject<string>
    {
        public ZipCode(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 5)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Latitude : SingleValueObject<decimal>
    {
        public Latitude(decimal value) : base(value)
        {
            
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Longitude : SingleValueObject<decimal>
    {
        public Longitude(decimal value) : base(value)
        {

        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Code3 : SingleValueObject<string>
    {
        public Code3(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 3)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Code10 : SingleValueObject<string>
    {
        public Code10(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 10)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Code : SingleValueObject<string>
    {
        public Code(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    public class FirstName : Name
    {
        public FirstName(string value) : base(value)
        {
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class LastName : SingleValueObject<string>
    {
        public LastName(string value) : base(value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length < 3)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Description : SingleValueObject<string>
    {
        public Description(string value) : base(value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length <= 5)
            {
                throw DomainError.With($"Invalid {this.GetType().PrettyPrint()} '{value}'");
            }
        }
    }

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class NameNullable : SingleValueObject<string>
    {
        public NameNullable(string value) : base(value) { }
    }
}
