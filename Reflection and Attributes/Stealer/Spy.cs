using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
  public class Spy
    {
        public string StealFieldInfo(string name,params string[]fields)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(name);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public |BindingFlags.NonPublic |BindingFlags.Instance |BindingFlags.Static);
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {classType}");
            foreach(FieldInfo field in classFields.Where(x=>fields.Contains(x.Name)))
              {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
      public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private");
            }
            foreach(MethodInfo method in classPublicMethods.Where(x=>x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private");
            }
            foreach (MethodInfo method in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public");
            }
            return sb.ToString().Trim();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach(var method in methods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }
        public string CollectGettersSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public );
            foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First()}");
            }
            return sb.ToString().Trim();
        }
    }
}
