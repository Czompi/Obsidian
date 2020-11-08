﻿using Obsidian.API.Plugins;
using Obsidian.API.Plugins.Services;
using Obsidian.API.Plugins.Services.IO;
using Obsidian.Plugins.ServiceProviders;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Obsidian.Plugins.Services
{
    public class FileWriterService : SecuredServiceBase, IFileWriter
    {
        internal override PluginPermissions NeededPermission => PluginPermissions.CanWrite;

        public FileWriterService(PluginContainer plugin) : base(plugin)
        {
        }

        public void AppendText(string path, string value)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            File.AppendAllText(path, value);
        }

        public Task AppendTextAsync(string path, string value, CancellationToken cancellationToken = default)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            return File.AppendAllTextAsync(path, value, cancellationToken);
        }

        public IStream OpenWrite(string path)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            return new WritingStreamService(File.OpenWrite(path));
        }

        public void WriteAllBytes(string path, byte[] value)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            File.WriteAllBytes(path, value);
        }

        public Task WriteAllBytesAsync(string path, byte[] value, CancellationToken cancellationToken = default)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            return File.WriteAllBytesAsync(path, value, cancellationToken);
        }

        public void WriteAllLines(string path, string[] value)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            File.WriteAllLines(path, value);
        }

        public Task WriteAllLinesAsync(string path, string[] value, CancellationToken cancellationToken = default)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            return File.WriteAllLinesAsync(path, value, cancellationToken);
        }

        public void WriteAllText(string path, string value)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            File.WriteAllText(path, value);
        }

        public Task WriteAllTextAsync(string path, string value, CancellationToken cancellationToken = default)
        {
            if (!IsUsable)
                throw new SecurityException(IFileWriter.securityExceptionMessage);

            return File.WriteAllTextAsync(path, value, cancellationToken);
        }

        //public string GetWorkingDirectory() => Path.GetDirectoryName(plugin.Source);
        //public string GetWorkingDirectory() => Path.Combine(Path.GetDirectoryName(plugin.Source), plugin.Plugin.Info.Name.Replace(" ", ""));
        /*public string GetWorkingDirectory(bool skipDefaultPluginDir = false) => skipDefaultPluginDir switch
        {
            true => Path.GetDirectoryName(plugin.Source),
            false => Path.Combine(Path.GetDirectoryName(plugin.Source), plugin.Plugin.Info.Name.Replace(" ", ""))
        };*/
        public string GetWorkingDirectory(bool createOwnDirectory = true, bool skipFolderAutoGeneration = false)
        {
            var workingDir = createOwnDirectory switch
            {
                true => Path.Combine(Path.GetDirectoryName(plugin.Source), plugin.Plugin.Info.Name.Replace(" ", "")),
                false => Path.GetDirectoryName(plugin.Source)
            };

            if (createOwnDirectory && !skipFolderAutoGeneration && !Directory.Exists(workingDir)) Directory.CreateDirectory(workingDir);

            return workingDir;
        }
    }
}
