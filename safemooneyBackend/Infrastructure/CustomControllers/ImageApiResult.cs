﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharedResourcesLibrary.Models;
using System.IO;
using System.Web.Http;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace safemooneyBackend.Infrastructure.CustomControllers
{
    public class ImageApiResult : IHttpActionResult
    {
        private Stream _bitmap;
        private int _contentLength;
        private static String _contentType = "image/jpeg";

        public ImageApiResult(UserImage img)
        {
            if (img == null)
                throw new ArgumentNullException("img is NULL");

            _bitmap = new MemoryStream(img.Data);
            _contentLength = img.Data.Length;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var result = new HttpResponseMessage();
            result.Content = new StreamContent(_bitmap);
            result.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue(_contentType);

            result.Content.Headers.ContentLength = _contentLength;
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue(System.Net.Mime.DispositionTypeNames.Inline);

            return Task.FromResult<HttpResponseMessage>(result);
        }
    }
}