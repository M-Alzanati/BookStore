using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;

namespace BookStore.API.Middlewares
{
    /// <summary>
    /// This middleware is used to log request with body, log response with body
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        private readonly ILogger _logger;

        private readonly RequestDelegate _next;

        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory
                  .CreateLogger<RequestResponseLoggingMiddleware>();
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();   // use this class instead of MemoryStream class to avoid memory leaks
        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequrest(context);
            await LogResponse(context);
        }

        private async Task LogRequrest(HttpContext context)
        {
            context.Request.EnableBuffering();  // write small object to memory, and large than 30k to disk
            await using var requestStream = _recyclableMemoryStreamManager.GetStream(); // get optimized stream that avoids Large object heap
            await context.Request.Body.CopyToAsync(requestStream);

            _logger.LogInformation($"Http Request Information:{Environment.NewLine}" +
                                   $"Schema:{context.Request.Scheme} " +
                                   $"Host: {context.Request.Host} " +
                                   $"Path: {context.Request.Path} " +
                                   $"QueryString: {context.Request.QueryString} " +
                                   $"Request Body: {ReadStreamInChunks(requestStream)}");

            context.Request.Body.Position = 0;
        }

        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();  // get optimized stream that avoids Large object heap
            context.Response.Body = responseBody;

            await _next(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();  // read stream and return string
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInformation($"Http Response Information:{Environment.NewLine}" +
                                   $"Schema:{context.Request.Scheme} " +
                                   $"Host: {context.Request.Host} " +
                                   $"Path: {context.Request.Path} " +
                                   $"QueryString: {context.Request.QueryString} " +
                                   $"Response Body: {text}");

            await responseBody.CopyToAsync(originalBodyStream);
        }

        /// <summary>
        /// This method is used to convert stream into string, 
        /// this method will divide stream into 4096 byte and read every chunk then append to stringwriter
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096; // amount 
            stream.Seek(0, SeekOrigin.Begin);   // set position to the start

            using var textWriter = new StringWriter();  // this class uses stringbuilder to avoid using string which is immutable and lead to memory leaks
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();   // convert stream bytes to string
        }
    }
}