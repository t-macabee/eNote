﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) { }
    }
}
