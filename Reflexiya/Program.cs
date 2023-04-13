using System;
using System.Reflection;

namespace Reflexiya
{
    public class Program
    {
        static void Main()
        {
            Type myType = typeof(ApplicationId);

            //Metods
            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string modificator = "";

                if (method.IsAbstract)
                    modificator += "protected ";
                else if (method.IsFamily)
                    modificator += "protected ";
                else if (method.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (method.IsFamilyOrAssembly)
                    modificator += "protected internal ";
                else if (method.IsAssembly)
                    modificator += "internal ";
                else if (method.IsPrivate)
                    modificator += "private ";
                else if (method.IsPublic)
                    modificator += "public ";
                else if (method.IsConstructor)
                    modificator += "private protected ";
                else if (method.IsVirtual)
                    modificator += "private protected ";

                if (method.IsStatic) 
                    modificator += "static ";
                Console.WriteLine($"{modificator} {method.ReturnType.Name} {method.Name} ()");
            }
            Console.WriteLine();

            //Constructors
            Console.WriteLine("Конструкторы:");
            foreach (ConstructorInfo ctor in myType.GetConstructors(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                string modificator = "";

                if (ctor.IsFamily) 
                    modificator += "protected";
                else if (ctor.IsFamilyAndAssembly) 
                    modificator += "private protected";
                else if (ctor.IsFamilyOrAssembly) 
                    modificator += "protected internal";
                else if (ctor.IsAssembly) 
                    modificator += "internal";
                else if (ctor.IsPrivate)
                    modificator += "private";
                else if (ctor.IsPublic) 
                    modificator += "public";
                

                Console.Write($"{modificator} {myType.Name}(");
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")\n");
            }

            
            //Fields
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string modificator = "";

                if (field.IsFamily)
                    modificator += "protected ";
                else if (field.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (field.IsFamilyOrAssembly)
                    modificator += "protected internal ";
                else if (field.IsAssembly)
                    modificator += "internal ";
                else if (field.IsPrivate)
                    modificator += "private ";
                else if (field.IsPublic)
                    modificator += "public ";

                if (field.IsStatic) modificator += "static ";

                Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
            }
            Console.WriteLine();

            //Properties
            Console.WriteLine("Свойства: ");
            foreach (PropertyInfo prop in myType.GetProperties(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                Console.Write($"{prop.PropertyType} {prop.Name} {{");

                if (prop.CanRead) Console.Write($"get = {prop.GetMethod};");
                if (prop.CanWrite) Console.Write($"set = {prop.SetMethod};");
                Console.Write("}");
                Console.WriteLine($" {prop.Attributes}");
            }
        }
    }
}