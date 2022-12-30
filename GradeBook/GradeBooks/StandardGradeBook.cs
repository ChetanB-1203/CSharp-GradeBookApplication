using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        string name;

        GradeBookType type;
        bool isWeighted;
        public StandardGradeBook(string name, bool isWeighted) : base(name,isWeighted)
        {
            this.name = name;
            type = GradeBookType.Standard;
            this.isWeighted = isWeighted;
        }
    }
}
