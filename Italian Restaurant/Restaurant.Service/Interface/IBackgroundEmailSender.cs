using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
