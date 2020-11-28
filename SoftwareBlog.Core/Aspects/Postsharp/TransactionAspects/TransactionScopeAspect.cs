using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace SoftwareBlog.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        //parametreli
        private TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }
        //parametresiz
        public TransactionScopeAspect()
        {

        }
        //methodun başında TransactionScope u açıyuorduk 
        public override void OnEntry(MethodExecutionArgs args)
        {
           args.MethodExecutionTag=new TransactionScope(_option);
        }
        //başarılı olduğunda
        public override void OnSuccess(MethodExecutionArgs args)
        {
          ((TransactionScope) args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
