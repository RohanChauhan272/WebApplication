using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAppPort.Entities.MainModel
{
    public class MainModel
    {
        public List<Main> mainModels { get; set; }
        public List<Project> projects { get; set; }
    }

    public class MainServiceModel
    {
        public List<Service> mainService { get; set; }
    }

    public class MainAboutModel
    {
        public List<About> about { get; set; }
        public List<About> aboutdet { get; set; } 
        public List<Team> TeamDet { get; set; }
    }

    public class Team
    {
        public string TeamName { get; set; }
        public string TeamPosition { get; set; }
    }
    
    public class Service
    {
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    }
    public class Main
    {
        public string IndustryTitle { get; set; }
        public string ImageName { get; set; }

        public byte[] ImageData { get; set; }
        public string Description { get; set; }
    }

    public class Project
    {
        public string ProjectTitle { get; set; }
        public string ProjectImageName { get; set; }

        public byte[] ProjectImageData { get; set; }
        public string ProjectDescription { get; set; }
    }

    public class About
    {
        public string AboutTitle { get; set; }
        public string AboutImageName { get; set; }

        public byte[] AboutImageData { get; set; }
        public string AboutDescription { get; set; }
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
