﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAppPort.Entities.MainModel
{
    public class MainModel
    {
        public List<Main> mainModels { get; set; }
        public List<About> abouts { get; set; }
    }

    public class Main
    {
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
    }

    public class About
    {
        public string Header { get; set; }
        public string Subheader { get; set; }
        public List<string> Description { get; set; }
        public string image { get; set; }
    }

    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; }
    }

    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
    }

}