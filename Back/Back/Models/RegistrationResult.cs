﻿namespace Back.Models
{
    public class RegistrationResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string>? Errors { get; set; }

    }
}
