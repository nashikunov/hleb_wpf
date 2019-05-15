using Hleb.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hleb.Classes
{
    public class Factory
    {
        private static Factory _instance;

        public static Factory Instance => _instance ?? (_instance = new Factory());

        private IRepository _repo;

        //не удаляйте, это нужно)))
        public IRepository GetRepository() => _repo ?? (_repo = new DbRepository());
    }
}