using System;
using System.Collections.Generic;
using System.Text;
using WebAppPort.Data.IRepository;
using WebAppPort.Entities.MainModel;

namespace WebAppPort.Data.Repository
{
    public class MainRepo : IMainRepo
    {
        public MainModel GetMainData()
        {
            try
            {
                MainModel mainData = new MainModel();

                List<Main> main = new List<Main>
                {
                    new Main { Header = "Architecture Firm",
                    SubHeader = "We Love",
                    image = "imgIndu/bg_1.jpg",
                    Description="A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth."
                    },
                    new Main {
                        Header="Since-2024",
                        SubHeader = "We Create Amazing Architecture Designs",
                    Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",
                    image = "imgIndu/bg_2.jpg" },
                    new Main {
                        Header="Since-We make",
                        SubHeader = "We Make Some Changes",
                    Description = "We Love We Create Amazing Architecture Designs A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",
                    image = "imgIndu/bg_3.jpg" }
                };

                List<About> about = new List<About>
                {
                    new About { Header = "Architecture Firm",
                    Subheader = "We Love",
                    image = "images/bg_1.jpg",
                    Description=new List<string>{
                         "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.",
                         "jfasjkdfasjkdfhasjkfhjkashdfjkashfjk"
                     }
                    }
                };

                mainData =new MainModel { mainModels = main, abouts = about };
                return mainData;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
