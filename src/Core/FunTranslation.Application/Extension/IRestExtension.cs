﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Extension
{
    public interface IRestExtension
    {
        Task<RestResponse> Get(string url);
    }
}
