using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Linapl.SystemMonitoring.FolderMonitoring
{
    public class FolderMonitor
    {
        private string _path;
        public bool IsMonitoring;
        private HashSet<string> _previousFolderState;

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
            while (true)
            {
                if (IsMonitoring)
                {
                    TrackChanges();
                    Thread.Sleep(1000);
                    Console.WriteLine("\n1 second\n");
                }
            }
        }

        public void TrackChanges()
        {
            var _latestFolderState = GetFolderState();
            var _deleteFolder = CheckChanges( new HashSet<string>(_previousFolderState), new HashSet<string>( _latestFolderState));
            var _addedFoulder = CheckChanges(new HashSet<string>(_latestFolderState), new HashSet<string>(_previousFolderState));
            
            foreach (var s in _deleteFolder)
            {
                Console.WriteLine($"the foulder {s} was deleted! ");
            }

            foreach (var s in _addedFoulder)
            {
                Console.WriteLine($"the foulder {s} was added! ");
            }

            _previousFolderState = _latestFolderState;
            _deleteFolder.Clear();
            _addedFoulder.Clear();
        }

        public HashSet<string> GetFolderState()
        {
            var lst = Directory.EnumerateDirectories(_path);
            HashSet<string> ret = new HashSet<string>();

            foreach(var s in lst)
            {
                ret.Add(s);
            }
            return ret;
        }

        public HashSet<string> CheckChanges(HashSet<string> dict1, HashSet<string> dict2)
        {
            dict1.ExceptWith(dict2);
            return dict1;
        }
    }
}
