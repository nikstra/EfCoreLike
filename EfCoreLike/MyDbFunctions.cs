using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System;
using System.Linq;
using System.Reflection;

namespace EfCoreLike
{
    public static class MyDbFunctions
    {
        const string EXCEPTION_MESSAGE = "DbFunction. Do not call, use only with LINQ to Entities.";

        public static string Convert(this DateTime date, string type, int format) =>
            throw new Exception(EXCEPTION_MESSAGE);

        public static void Register(ModelBuilder modelBuider)
        {
            var methodInfo = typeof(MyDbFunctions)
                .GetRuntimeMethod(
                    nameof(Convert),
                    new[]
                    {
                        typeof(DateTime),
                        typeof(string),
                        typeof(int)
                    });

            modelBuider.HasDbFunction(methodInfo)
                .HasTranslation(args =>
                    SqlFunctionExpression.Create(
                        methodInfo.Name,
                        new[]
                        {
                            new SqlFragmentExpression("VARCHAR(max)"),
                            args.First()
                        },
                        typeof(string),
                        new SqlServerStringTypeMapping()));

            // TODO: Investigate if we can avoid using internal class SqlServerStringTypeMapping.
        }
    }
}
