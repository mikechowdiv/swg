﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Tables;

namespace Data.Interfaces
{
  public  interface IMakesRepository
  {
      List<MakesType> GetAll();
  }
}