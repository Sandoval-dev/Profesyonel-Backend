using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;

        ICacheManager _cachemanager;

        public CacheAspect(Type cacheType, int cacheByMinute=60)
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
            _cachemanager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);

        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name, args.Method.Name);

            var arguments=args.Arguments.ToList();

            var key=string.Format("{0}({1})",methodName,string.Join(", ",arguments.Select(x=>x!=null?x.ToString():"<Null>")));

            if (_cachemanager.IsAdd(key))
            {
                args.ReturnValue = _cachemanager.Get<object>(key);
            }
            base.OnInvoke(args);
            _cachemanager.Add(key, args.ReturnValue, _cacheByMinute);
        }
    }
}
