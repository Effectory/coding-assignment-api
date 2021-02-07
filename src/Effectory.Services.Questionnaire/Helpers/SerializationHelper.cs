using System;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Effectory.Services.Questionnaire.Helpers
{
    public static class SerializationHelper
    {
        public static Lazy<JsonSerializerOptions> SerializerOptions = new Lazy<JsonSerializerOptions>(() =>
        {
            var settings = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            return settings;
        });
    }
}
