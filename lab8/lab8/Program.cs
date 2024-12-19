using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    using System;
    using System.Collections.Generic;

    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;

        private Dictionary<string, string> _settings;

        private ConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
        }

        public static ConfigurationManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }

        public string GetSetting(string key)
        {
            if (_settings.ContainsKey(key))
            {
                return _settings[key];
            }
            return null;
        }

        public void SetSetting(string key, string value)
        {
            if (_settings.ContainsKey(key))
            {
                _settings[key] = value;
            }
            else
            {
                _settings.Add(key, value);
            }
        }

        public void ShowSettings()
        {
            Console.WriteLine("Конфігураційні налаштування:");
            foreach (var setting in _settings)
            {
                Console.WriteLine($"{setting.Key}: {setting.Value}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var configManager = ConfigurationManager.GetInstance();

            configManager.SetSetting("LoggingMode", "Verbose");
            configManager.SetSetting("DatabaseConnection", "Server=myServer;Database=myDB;");

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Показати налаштування");
                Console.WriteLine("2. Змінити налаштування");
                Console.WriteLine("3. Вийти");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    configManager.ShowSettings();
                }
                else if (choice == "2")
                {
                    Console.Write("Введіть ключ налаштування: ");
                    var key = Console.ReadLine();
                    Console.Write("Введіть нове значення: ");
                    var value = Console.ReadLine();

                    configManager.SetSetting(key, value);
                    Console.WriteLine("Налаштування змінено!");
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                }
            }
        }
    }
}
