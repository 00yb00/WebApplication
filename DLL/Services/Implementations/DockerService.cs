using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class DockerService
    {
        public async Task<string> RunComposeUpAsync(string composeFilePath)
        {
            return await RunDockerComposeCommandAsync($"-f \"{composeFilePath}\" up -d");
        }

        public async Task<string> RunComposeDownAsync(string composeFilePath)
        {
            return await RunDockerComposeCommandAsync($"-f \"{composeFilePath}\" down");
        }

        private async Task<string> RunDockerComposeCommandAsync(string arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "docker-compose",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var process = new Process { StartInfo = startInfo };
            process.Start();

            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            await process.WaitForExitAsync();

            if (!string.IsNullOrEmpty(error))
                return $"Error: {error}";

            return output;
        }
    }
}
