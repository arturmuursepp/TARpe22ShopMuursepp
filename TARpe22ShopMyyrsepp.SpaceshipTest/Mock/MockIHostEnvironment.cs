﻿using Microsoft.Extensions.FileProviders;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace TARpe22ShopMyyrsepp.SpaceshipTest.Mock
{
    public class MockIHostEnvironment : IHostingEnvironment
    {
        public string EnvironmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContentRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string WebRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider WebRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
