﻿using ErrorOr;

namespace Application.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "Register.DuplicateEmail",
                description: "Email already exists.");
        }
    }
}
