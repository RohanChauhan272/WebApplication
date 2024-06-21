using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppPort.Entities.MainModel;

namespace WebAppPort.Data.IRepository
{
    public interface IMainRepo
    {
        MainModel GetMainData();
        MainAboutModel GetAboutMainData();

        MainServiceModel GetServiceMainData();
        void SaveImageToDatabase(string imageName, byte[] imageData);
    }
}
