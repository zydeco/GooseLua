using System;
using System.Collections.Generic;
using System.IO;
using IniParser;
using IniParser.Exceptions;
using IniParser.Model;
using MoonSharp.Interpreter;

namespace GooseLua.Lua {
    [MoonSharpUserData]
    class Config {
        public string configFilePath { get; private set; }
        public IniData config { get; private set; }
        private FileSystemWatcher watcher;

        [MoonSharpHidden]
        public Config(string configFilePath) {
            this.configFilePath = configFilePath;
            LoadConfigFile();
        }

        private void LoadConfigFile() {
            if (File.Exists(configFilePath)) {
                var parser = new FileIniDataParser();
                config = parser.ReadFile(configFilePath);
            } else {
                config = new IniData();
            }
            var directory = Path.GetDirectoryName(configFilePath);
            var fileName = Path.GetFileName(configFilePath);
            watcher = new FileSystemWatcher(directory, fileName);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.CreationTime;
            watcher.Changed += ReloadConfigFile;
            watcher.Created += ReloadConfigFile;
            watcher.Renamed += ReloadConfigFile;
            watcher.EnableRaisingEvents = true;
        }

        private void ReloadConfigFile(object _, FileSystemEventArgs args)
        {
            if (!File.Exists(configFilePath))
            {
                return;
            }
            try
            {
                var parser = new FileIniDataParser();
                var newConfig = parser.ReadFile(configFilePath);
                config = newConfig;
            } catch (ParsingException)
            {
            }
        }

        private void WriteConfigFile() {
            var parser = new FileIniDataParser();
            parser.WriteFile(configFilePath, config);
        }

        public void Register(string sectionName, Dictionary<string, string> values) {
            // add section
            if (!config.Sections.ContainsSection(sectionName)) {
                config.Sections.AddSection(sectionName);
            }

            // add values
            var section = config[sectionName];
            foreach(var item in values) {
                if (section.ContainsKey(item.Key)) {
                    continue;
                }
                section[item.Key] = item.Value;
            }

            WriteConfigFile();
        }

        public DynValue Get(string section, string key, DynValue defaultValue = null) {
            if (config.Sections.ContainsSection(section) && config[section].ContainsKey(key)) {
                return DynValue.NewString(config[section][key]);
            }
            return defaultValue ?? DynValue.Nil;
        }

        public void Set(string section, string key, DynValue value) {
            config[section][key] = value.CastToString() ?? value.ToString();
            WriteConfigFile();
        }
    }
}
