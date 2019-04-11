using QuickStartMenu.Domain.Interfaces;
using System;
using System.IO;

namespace QuickStartMenu.Infrastructure.FileSystem
{
    public class FolderState : IObjectState
    {
        private readonly DirectoryInfo _directory;
        private DateTime _lastWriteTimeUtc = DateTime.MinValue;

        public FolderState(DirectoryInfo directory)
        {
            _directory = directory;
        }

        public bool HasChanged()
        {
            _directory.Refresh();
            return _directory.LastWriteTimeUtc > _lastWriteTimeUtc;
        }

        public void Update()
        {
            _directory.Refresh();
            _lastWriteTimeUtc = _directory.LastWriteTimeUtc;
        }
    }
}
