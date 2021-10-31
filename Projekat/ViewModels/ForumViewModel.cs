using System;
using System.Collections.Generic;
using System.Linq;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.ViewModels
{
    public class ForumViewModel
    {
        public IEnumerable<Forum_Post> postsModel { get; set; }
        public Forum_Post forum { get; set; }
        public IEnumerable<AspNetUser> UsersDetails { get; set; }
        public IEnumerable<Forum_Message> Forummessage { get; set; }
        public Forum_Message forum2 { get; set; }
    }
}