﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Demo.FunctionApp.Tests.Helpers
{
    public static class TestFactory
    {
        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[] {"name", "Bill"},
                new object[] {"name", "Jane"},
                new object[] {"name", "Ann"}
            };
        }

        public static HttpRequest CreateHttpRequest(string queryStringKey, string queryStringValue)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue));
            return request;
        }

        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            return new Dictionary<string, StringValues>
            {
                {key, value}
            };
        }
    }
}
