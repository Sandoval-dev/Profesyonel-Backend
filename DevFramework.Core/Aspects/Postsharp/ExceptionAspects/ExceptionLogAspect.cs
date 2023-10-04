using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect:OnExceptionAspect
    {

        public override void OnException(MethodExecutionArgs args)
        {
            base.OnException(args);
        }
    }
}
