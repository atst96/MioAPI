using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace MioAPI
{
    internal static class JsonUtils
    {
        private static readonly IJsonFormatterResolver _jsonFormatterResolver = Utf8Json.Resolvers.StandardResolver.AllowPrivate;

        public static string ToJsonString<T>(T @object)
        {
            return JsonSerializer.ToJsonString(@object, _jsonFormatterResolver);
        }

        public static Task<T> DeserializeAsync<T>(Stream stream)
        {
            return JsonSerializer.DeserializeAsync<T>(stream, _jsonFormatterResolver);
        }

        public static Task SerializeAsync<T>(T @object, Stream output)
        {
            return JsonSerializer.SerializeAsync(output, @object, _jsonFormatterResolver);
        }
    }
}
