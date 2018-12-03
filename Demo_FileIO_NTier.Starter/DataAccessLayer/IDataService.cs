﻿using Demo_FileIO_NTier.Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.Starter.DataAccessLayer
{
    public interface IDataService
    {
        IEnumerable<Character> ReadAll();
        void WriteAll(IEnumerable<Character> characters);
    }
}
