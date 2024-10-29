using ExternalData.PkmnGg.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pokelibrary.ExternalData.PkmnGg.Converters {
    public class VariantsConverter : JsonConverter<Card.Variant[]>
    {
        public override Card.Variant[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Ensure we're at the start of the object
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            List<Card.Variant>? variants = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException();

                // Move to the value, which is the Variant object
                reader.Read();

                var variant = JsonSerializer.Deserialize<Card.Variant>(ref reader, options);

                variants?.Add(variant);
            }

            return variants.ToArray();
        }

        public override void Write(Utf8JsonWriter writer, Card.Variant[] value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}