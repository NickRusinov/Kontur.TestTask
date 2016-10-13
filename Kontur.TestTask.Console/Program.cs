using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.TestTask.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                System.Console.WriteLine(@"Неверные аргументы командной строки");
                System.Console.WriteLine(@"Должно быть:");
                System.Console.WriteLine(@"  ""Имя исполняемого файла"" ""Имя файла с детьми"" ""Имя файла с симпатиями""");

                return;
            }
            
            try
            {
                using (var childsFile = File.Open(args[1], FileMode.Open, FileAccess.Read))
                using (var sympathiesFile = File.Open(args[2], FileMode.Open, FileAccess.Read))
                {
                    var childCollection = new ChildXmlFileReader(childsFile).ReadFile().ToList();
                    var sympathyCollection = new SympathyXmlFileReader(sympathiesFile).ReadFile(childCollection).ToList();

                    ProgramLoop(childCollection, sympathyCollection);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("В процессе выполнения программы произошла ошибка:");
                System.Console.WriteLine(e.Message);
            }

            System.Console.ReadKey();
        }

        private static void ProgramLoop(IReadOnlyCollection<Child> childs, IReadOnlyCollection<Sympathy> sympathies)
        {
            while (true)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Выберите задачу:");
                System.Console.WriteLine("    1. Вывести список всех не любимчиков, то есть детей которые никому не симпатичны");
                System.Console.WriteLine("    2. Вывести список всех несчастных детей, то есть тех, которые не симпатичны ни одному ребенку из тех, кто симпатичен им самим. За исключением тех детей, которым никто не симпатичен");
                System.Console.WriteLine("    3. Вывести список любимчиков, то есть всех детей, которые симпатичны максимальному количеству других детей");
                System.Console.WriteLine("    4. Выход");
                
                IService service = null;
                while (service == null)
                {
                    var input = System.Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            service =  new GetNoSympathyService();
                            break;

                        case ConsoleKey.D2:
                            service = new GetUnhappyService();
                            break;

                        case ConsoleKey.D3:
                            service = new GetSympathyService();
                            break;

                        case ConsoleKey.D4:
                            return;
                    }
                }

                System.Console.WriteLine();

                var result = service.Execute(childs, sympathies);
                var i = 1;
                foreach (var child in result)
                    System.Console.WriteLine($"{i++}: {child.Name}");
            }
        }
    }
}
