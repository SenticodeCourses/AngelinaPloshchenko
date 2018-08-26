using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Linapl.SystemMonitoring.FolderMonitoring
{
    public class FolderMonitor
    {
        private string _path;
        public bool _isMonitoring;
        private Dictionary<string, bool> _previousFolderState = new Dictionary<string, bool>();

        public FolderMonitor(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException();
            }
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }
            _path = path;
            _previousFolderState = GetFolderState();
        }

        public void Monitoring()
        {
            while (_isMonitoring)
            {
                TrackChanges();
                Thread.Sleep(10000);
                Console.WriteLine("\n10 second\n");
            }
        }

        public void TrackChanges()
        {
            var _latestFolderState = GetFolderState();
            var _deleteFolder = CheckChanges(_previousFolderState, _latestFolderState);
            var _addedFoulder = CheckChanges(_latestFolderState, _previousFolderState);

            foreach (var s in _deleteFolder)
            {
                Console.WriteLine($"the foulder {s} was deleted! ");
            }

            foreach (var s in _addedFoulder)
            {
                Console.WriteLine($"the foulder {s} was added! ");
            }
            _previousFolderState = _latestFolderState;
        }

        public Dictionary<string, bool> GetFolderState()
        {
            var lst = Directory.EnumerateDirectories(_path)
                .ToDictionary(i => i, i => false);
            return lst;
        }

        public List<string> CheckChanges(Dictionary<string, bool> dict1, Dictionary<string, bool> dict2)
        {
            List<string> lst = new List<string>();
            foreach (var s in dict1)
            {
                if (!dict2.TryGetValue(s.Key, out var folderName))
                {
                    lst.Add(s.Key.ToString());
                }
            }
            return lst;
        }
    }
}
// 1. Получить список файлов и папок внутри указанной папки
// 2. Сохранение полученного списка
// 3. Сравнение двух списков
