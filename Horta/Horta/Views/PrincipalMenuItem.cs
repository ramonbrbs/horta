﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horta.Views
{

    public class PrincipalMenuItem
    {
        public PrincipalMenuItem()
        {
            TargetType = typeof(PrincipalDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}