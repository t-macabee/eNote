﻿using System;

namespace eNote.Model
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) { }
    }
}
