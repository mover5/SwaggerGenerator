using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerArgs;
using System.ComponentModel;
using System.Reflection;

namespace SwaggerGenerator
{
    public class SwaggerGeneratorActionResolver : ArgActionResolver
    {
        public override IEnumerable<Type> ResolveActionTypes()
        {
            new BackgroundWorker();

            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.HasAttr<ArgActions>() && t.Namespace.Contains("Actions"));
        }
    }

    [SwaggerGeneratorActionResolver]
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    [TabCompletion(REPL = true, REPLWelcomeMessage = @"CSDEF\CSDFG Settings Helper Tool", HistoryToSave = 100)]
    public class Program
    {
        static void Main(string[] args)
        {
            Args.InvokeAction<Program>(args);
        }
    }
}
