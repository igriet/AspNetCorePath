using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Data
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
    }
}
