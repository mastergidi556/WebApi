﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Shared
{
    public class UserManagerResponse
    {
        public string Message { get; set; }

        public bool isSuccess { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public DateTime? Expiration { get; set; }
    }
}
