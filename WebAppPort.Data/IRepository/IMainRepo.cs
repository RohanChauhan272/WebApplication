using System;
using System.Collections.Generic;
using System.Text;
using WebAppPort.Entities.MainModel;

namespace WebAppPort.Data.IRepository
{
    public interface IMainRepo
    {
        MainModel GetMainData();
    }
}
