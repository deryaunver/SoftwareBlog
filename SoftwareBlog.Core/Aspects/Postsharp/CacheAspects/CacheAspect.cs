using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using SoftwareBlog.Core.CrossCuttingConcerns.Caching;

namespace SoftwareBlog.Core.Aspects.Postsharp.CacheAspects
{
   public class CacheAspect:MethodInterceptionAspect
   {
       private Type _cacheType;
       private int _cacheByMinute;
       private ICacheManager _cacheManager;

       public CacheAspect(Type cacheType, int cacheByMinute)
       {
           _cacheType = cacheType;
           _cacheByMinute = cacheByMinute;
       }

       public override void RuntimeInitialize(MethodBase method)
       {
           if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
           {
               throw new Exception("Wrong Cache Manager");
           }

           _cacheManager = (ICacheManager) Activator.CreateInstance(_cacheType);

           base.RuntimeInitialize(method);
       }
   }
}
