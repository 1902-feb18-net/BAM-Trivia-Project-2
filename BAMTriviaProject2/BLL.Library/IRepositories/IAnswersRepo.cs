﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IAnswersRepo
    {
        void GetAnswerByQuestion(int questionId);
    }
}
