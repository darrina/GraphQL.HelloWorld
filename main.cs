using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson; // First add PackageReference to GraphQL.SystemTextJson

static partial class Program {
  static async Task Main() {
    var schema = Schema.For(@"
      type Query {
        hello: String
      }
    ");
    
    var root = new { Hello = "Hello World!" };
    var json = await schema.ExecuteAsync(_ =>
    {
      _.Query = "{ hello }";
      _.Root = root;
    });
    
    Console.WriteLine(json);
  }
}
