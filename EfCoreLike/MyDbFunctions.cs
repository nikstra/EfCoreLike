using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
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
            var convertMethodInfo = GetMethodInfoForConvert();
            modelBuider
                .HasDbFunction(convertMethodInfo)
                .HasTranslation(args =>
                {
                    var arguments = args.ToArray();
                    var sqlTypeName = (string)((SqlConstantExpression)arguments[1]).Value;
                    return SqlFunctionExpression.Create(
                        convertMethodInfo.Name,
                        new[]
                        {
                            new SqlFragmentExpression($"{sqlTypeName}(max)"),
                            arguments[0],
                            arguments[2]
                        },
                        convertMethodInfo.ReturnType,
                        new StringTypeMapping(sqlTypeName, DbType.String));
                });
        }

        private static MethodInfo GetMethodInfoForConvert() =>
            typeof(MyDbFunctions)
                .GetRuntimeMethod(
                    nameof(Convert),
                    new[]
                    {
                        typeof(DateTime),
                        typeof(string),
                        typeof(int)
                    });
    }
}
